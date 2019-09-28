using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartMaintenanceWebApi.Models;

namespace SmartMaintenanceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        //Constructor
        public AccountController(UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }

        /*Authorize attribute, which tells MVC that only requests from authenticated
          users should be processed*/
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> LALA()
        {
            return new string[] { "value1", "value3" };
        }

        //Respond to POST method
        [HttpPost("login")]
        // allows unauthenticated users to log into the application
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel text)
        {
            Console.WriteLine("fafa");
                //This method locates a user account using the e-mail address that was used to create it.
                AppUser user = await userManager.FindByEmailAsync(text.Email);
                if (user != null)
                {
                    // await = asynchronous
                    // SignOutAsync method cancels any existing session that the user has
                    await signInManager.SignOutAsync();
                    // PasswordSignIn method performs the authentication
                    Microsoft.AspNetCore.Identity.SignInResult result =
                    await signInManager.PasswordSignInAsync(
                    user, text.Password, false, false);

                    if (result.Succeeded)
                    {
                        //If login success, store the email to the session variable
                        //HttpContext.Session.SetString("SessionEmail", details.Email);           
                        // redirect the user to the returnUrl location if it is true and if it is false, add a validation error and redisplay the Login view to the user so they can try again.
                        return Ok();

                    }
                
            }
            return Unauthorized();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}