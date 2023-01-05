using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace floristWebApp.Models
{
    public class UpdateProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty.")]
        public string Name { get; set; }
        [Range(1, double.MaxValue, ErrorMessage ="Price must be bigger than 0.")]
        public decimal Price { get; set; }
        public IFormFile Photo { get; set; }
    }
}
