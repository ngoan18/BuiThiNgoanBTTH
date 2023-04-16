using System.ComponentModel.DataAnnotations;
namespace BaiThucHanh1004.Models
{
    public class Employee
    {
        [Key]
        public string ID{get; set;}
        public string FullName{get; set;}
    }
}
