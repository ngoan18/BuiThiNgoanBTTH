using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using baithuchanh04.Models;
using baithuchanh04.Models.Process;

namespace baithuchanh04.Controllers
{
    public class FacultyController : Controller
    {
        private readonly MvcMovieContext _context;
          private StringProcess strPro = new StringProcess();  
          private ExcelProcess _excelProcess = new ExcelProcess();     

        public FacultyController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Faculty
        public async Task<IActionResult> Index()
        {
              return _context.Faculty != null ? 
                          View(await _context.Faculty.ToListAsync()) :
                          Problem("Entity set 'MvcMovieContext.Faculty'  is null.");
        }

        // GET: Faculty/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Faculty == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculty
                .FirstOrDefaultAsync(m => m.FacultyID == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // GET: Faculty/Create
        public IActionResult Create()
        {
              var newID = "";
            if (_context.Faculty.Count() == 0)
            {
                //khoi tao 1 ma moi
                newID = "FR001";
            }
            else
            {
                var id = _context.Faculty.OrderByDescending(m => m.FacultyID).First().FacultyID;
                newID = strPro.AutoGenerateCode(id);
            }
            ViewBag.FacultyID = newID;
            return View();
        }

        // POST: Faculty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacultyID,FacultyName,FacultyEmail")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faculty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }

        // GET: Faculty/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Faculty == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculty.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }

        // POST: Faculty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FacultyID,FacultyName,FacultyEmail")] Faculty faculty)
        {
            if (id != faculty.FacultyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(faculty.FacultyID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }

        // GET: Faculty/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Faculty == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculty
                .FirstOrDefaultAsync(m => m.FacultyID == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: Faculty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Faculty == null)
            {
                return Problem("Entity set 'MvcMovieContext.Faculty'  is null.");
            }
            var faculty = await _context.Faculty.FindAsync(id);
            if (faculty != null)
            {
                _context.Faculty.Remove(faculty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyExists(string id)
        {
          return (_context.Faculty?.Any(e => e.FacultyID == id)).GetValueOrDefault();
        }
          public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Upload(IFormFile file)
        {
            if (file!=null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    //rename file when upload to sever
                    var fileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to server
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //dùng vòng l?p for d? d?c d? li?u d?ng hd
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //create a new Student object
                            var Faculty = new Faculty();
                            //set values for attribiutes
                            Faculty.FacultyID = dt.Rows[i][0].ToString();
                            Faculty.FacultyName = dt.Rows[i][1].ToString();
                            Faculty.FacultyEmail= dt.Rows[i][2].ToString();
                          
                                
                                                           //add oject to context
                            _context.Faculty.Add(Faculty);
                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
    }
    }
    }