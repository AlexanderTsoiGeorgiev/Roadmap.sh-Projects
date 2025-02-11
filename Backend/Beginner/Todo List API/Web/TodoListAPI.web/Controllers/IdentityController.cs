using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Data.Models;
using TodoListAPI.Web.Models.Identity;

namespace TodoListAPI.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        public IdentityController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = registerUserDTO.Username,
                    Email = registerUserDTO.Email
                };

                IdentityResult userCreation = await userManager.CreateAsync(user, registerUserDTO.Password);
                if (!userCreation.Succeeded)
                {
                    return StatusCode(500, userCreation.Errors);
                }

                //TODO seed roles
                // IdentityResult userAddedToRole = await userManager.AddToRoleAsync(user, "User");
                // if (!userAddedToRole.Succeeded)
                // {
                //     return StatusCode(500, userAddedToRole.Errors);
                // }

                return Ok(); 
            }
            catch (Exception)
            {
                return StatusCode(500, "Unexpecte Error Occured!");
            }
        }

        [HttpPost("Login")]
        public IActionResult LogIn()
        {
            return Ok();
        }
    }
}
