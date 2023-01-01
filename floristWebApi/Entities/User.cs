using Microsoft.AspNetCore.Identity;

namespace floristWebApi.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}
