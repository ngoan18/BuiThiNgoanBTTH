using System.ComponentModel.DataAnnotations;
namespace BaiThucHanh1704.Models;
  public class Student
   {
    [Key]
    public string StudentID { get; set; }
    public string FullName {get; set; }
    public string StudentEmail {get; set; }
    public string StudentPhone {get; set; }
    
   }
