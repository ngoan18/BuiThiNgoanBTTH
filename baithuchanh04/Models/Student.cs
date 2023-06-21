using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace baithuchanh04.Models
{
    public class Student
    {
        public string? StudentID{get; set;}
        public string? FullName{get; set;}
        public string? Address{get; set;}
        public string EmployeeID{get;set;}
        [ForeignKey("EmployeeID")]
        public Employee? Employee{get; set;}

    }
}