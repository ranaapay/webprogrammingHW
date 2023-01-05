using floristWebApi.Dtos;
using floristWebApi.Entities;
using floristWebApi.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace floristWebApi.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;

        public AuthenticationController(SignInManager<User> signInManager)
        {
            _signInManager= signInManager;
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            var signInResult = _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false).Result;
            if (signInResult.Succeeded)
            {
                return Ok(true);
            }
            return Ok(false);
        }

    }
}
