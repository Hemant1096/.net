using BackendAPI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser>? _userManager;
        private readonly RoleManager<IdentityRole>? _roleManager;

        public LoginController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //[HttpPost]
        //public ActionResult Register()
        //{
        //    returnModel retModel = new returnModel();
        //    retModel.success = true;
        //    retModel.message = "User Created Successfully";

        //    return Ok(retModel);
        //}

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            returnModel retModel = new returnModel();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new IdentityUser
            {
                UserName = model.Name,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Optionally assign role
            //if (!string.IsNullOrEmpty(model.Role))
            //{
            //    // Create role if it doesn't exist
            //    if (!await _roleManager.RoleExistsAsync(model.Role))
            //    {
            //        await _roleManager.CreateAsync(new IdentityRole(model.Role));
            //    }

            //    await _userManager.AddToRoleAsync(user, model.Role);
            //}
            retModel.success = true;
            retModel.message = "User Created Successfully";
            return Ok(retModel);
        }
    }
}
