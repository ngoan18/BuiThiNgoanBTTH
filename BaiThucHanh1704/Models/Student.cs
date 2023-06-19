using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiThucHanh1704.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        //Key cua class Student
        public string StudentID { get; set;}
        public string StudentName { get; set; }
        public string FacultyID { get; set; }
    
    }
}