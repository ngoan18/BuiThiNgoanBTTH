using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baithuchanh04.Models
{
    public class Customer
    {
        [Key]
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Number { get; set; }
    }
}
