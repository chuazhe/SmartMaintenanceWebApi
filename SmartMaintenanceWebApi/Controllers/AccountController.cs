using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartMaintenanceWebApi.Helpers;
using SmartMaintenanceWebApi.Models;

namespace SmartMaintenanceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // allows unauthenticated users
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        private readonly AppSettings _appSettings;

        //Constructor
        public AccountController(UserManager<AppUser> userMgr,
        SignInManager<AppUser> signinMgr, IOptions<AppSettings> appSettings)
        {
            userManager = userMgr;
            signInManager = signinMgr;
            _appSettings = appSettings.Value;
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            // delete token
            return RedirectToAction("Index", "Home");
        }

        //Respond to POST method
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel text)
        {
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

                    string userId = await userManager.GetUserIdAsync(user);
                    // Get a list of role that is assigned to the user
                    var userRoles = await userManager.GetRolesAsync(user);
                    Console.WriteLine(userRoles[0]);
                    Console.WriteLine(userRoles+userId);

                    // authentication successful so generate jwt token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    //get the signature
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    //unique_name
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    //role
                    new Claim(ClaimTypes.Role, userRoles[0])
                        }),
                        //exp
                        Expires = DateTime.UtcNow.AddDays(365),
                        //sign with signature, HMAC with SHA-256
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var token2= tokenHandler.WriteToken(token);


                    //If login success, store the email to the session variable
                    //HttpContext.Session.SetString("SessionEmail", details.Email);           
                    // redirect the user to the returnUrl location if it is true and if it is false, add a validation error and redisplay the Login view to the user so they can try again.
                    return Ok(token2.ToString());
              
                    }
                
            }
            return Unauthorized();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}