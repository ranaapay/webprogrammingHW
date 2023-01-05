using System.ComponentModel.DataAnnotations;

namespace floristWebApp.Models
{
    public class AddCategoryModel
    {
        [Required(ErrorMessage = "Name can not be empty.")]
        public string Name { get; set; }
    }
}
