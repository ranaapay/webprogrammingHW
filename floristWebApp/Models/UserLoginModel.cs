using System.ComponentModel.DataAnnotations;

namespace floristWebApp.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="UserName can not be empty.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password can not be empty.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
