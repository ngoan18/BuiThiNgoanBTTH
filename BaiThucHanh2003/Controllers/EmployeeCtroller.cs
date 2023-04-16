using Microsoft.AspNetCore.Mvc;
using BaiThucHanh2003.Models;

namespace BaiThucHanh2003.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Employee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Employee(Employee std)
        {
            string ketqua = std.EmployeeCode + "-" + std.EmployeeFullName + "-" + std.EmployeeAddress;
            ViewBag.abc = ketqua;
            return View();
        }

    }
}
