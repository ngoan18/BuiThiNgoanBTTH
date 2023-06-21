using System.ComponentModel.DataAnnotations;
namespace BaiThucHanh1704.Models;
public class Faculty
{
    [Key]
    public string FacultyID { get; set; }
    public string FacultyName { get; set; }
    public string FacultyEmail { get; set; }
}