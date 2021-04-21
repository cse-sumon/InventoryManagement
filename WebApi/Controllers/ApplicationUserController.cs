using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationSettings _appSettings;


        public ApplicationUserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,SignInManager<ApplicationUser> signInManager, IOptions<ApplicationSettings> appSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route("Register")]
       // [Authorize(Roles = "Admin")]
        //post: /api/ApplicationUser/Register
        public async Task<Object> Register(Register model)
        {
            try
            {
                var applicationUser = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                };

                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                await _userManager.AddToRoleAsync(applicationUser, model.Role);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPost]
        [Route("Login")]
        //post: /api/ApplicationUser/Login
        public async Task<IActionResult> Login(Login model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    //Get role assigned to the user
                    var role = await _userManager.GetRolesAsync(user);
                    IdentityOptions _options = new IdentityOptions();

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(securityToken);
                    return Ok(new { token });
                }
                else
                    return BadRequest(new { message = "UserName or Password is Incorrect." });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [HttpGet("GetUserProfile")]
        [Authorize]
        //Get: /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            try
            {
                string userId = User.Claims.FirstOrDefault(c => c.Type == "UserID").Value;
                var user = await _userManager.FindByIdAsync(userId);

                return new
                {
                    user.FullName,
                    user.UserName,
                    user.Email,
                    user.PhoneNumber,
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("GetAllRoles")]
        [Authorize]
        // Get: /api/ApplicationUser/GetAllRoles
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _roleManager.Roles.ToListAsync());
        }


        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "SuperAdmin")]
        // Get: /api/ApplicationUser/GetAllUsers
        public ActionResult GetAllUsers()
        {
            var result = (from user in _userManager.Users
                          join r in _roleManager.Roles on user.Id equals r.Id
                          
                          select new
                          {
                              Id = user.Id,
                              UserName = user.UserName,
                              FullName = user.FullName,
                              Email = user.Email,
                              PhoneNumber = user.PhoneNumber
                          }).ToList();

            return Ok(result);
        }


        [HttpDelete("deleteUser/{id}")]
        [Authorize(Roles = "SuperAdmin")]
        //Delete: /api/ApplicationUser/DeleteUser
        public async Task<ActionResult>  DeleteUser(string id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                await _userManager.DeleteAsync(user);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




    }
}
