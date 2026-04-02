using System.ComponentModel.DataAnnotations;
namespace CodeFirstEFASPDONTNETCOREDEMO.Models
{
    public class Customer
    {
        public int CustomerID {  get; set; }

        [Required]
        public string CustomerName { set; get; }

        public ICollection<Product> Products { set; get; }

    }
}
