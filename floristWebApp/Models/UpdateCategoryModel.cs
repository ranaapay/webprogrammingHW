using System.ComponentModel.DataAnnotations;

namespace floristWebApp.Models
{
    public class UpdateCategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can not be empty.")]
        public string Name { get; set; }
    }
}
