using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace baithuchanh04.Models

{
    public class Employee
    {
        public string EmployeeID{ get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeeAddress { get; set; }

    }
}
