using Microsoft.AspNetCore.Mvc;
using BaiThucHanh0703.Models;

namespace BaiThucHanh2003.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
       public IActionResult Create(Employee sdt)
        {
            string ketqua = sdt.EmployeeName +"-" + sdt.PhoneNumber;
            ViewBag.message = ketqua;
            return View();
        }
    }
}