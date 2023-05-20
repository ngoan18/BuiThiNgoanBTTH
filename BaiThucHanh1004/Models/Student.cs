using System.ComponentModel.DataAnnotations;
namespace BaiThucHanh1004.Models;

    public class Student
    {
        [Key]
        public String StudentID{get; set;}
        public string StudentName{get; set;}
        public string Address{get; set;}
    }