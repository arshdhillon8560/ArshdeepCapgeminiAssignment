using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace MVCExampleDemo.Models

{
    public class dog
    {
        [Required(ErrorMessage= "id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required"), MaxLength(222)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is required"), Range(0, 20, ErrorMessage = "Age should be between 0 to 20 only ")]
        public int Age { get; set; }
    }
}
