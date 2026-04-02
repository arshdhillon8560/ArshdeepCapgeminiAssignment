using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstEFASPDONTNETCOREDEMO.Models
{
    public class Product
    {
        public int ProductID { set; get; }

        public string ProductName { set; get; }
        [Display(Name ="Who buyed")]
        public int CustomerID { set; get; }

        [ForeignKey("CustomerID")]
        public Customer Customer { set; get; }

    }
}
