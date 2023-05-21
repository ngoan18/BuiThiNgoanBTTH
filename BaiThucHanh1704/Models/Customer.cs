using System.ComponentModel.DataAnnotations;
namespace BaiThucHanh1704.Models
{
    public class Customer
    {
        [Key]
        public string FullName { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Number { get; set; }
    }
}
