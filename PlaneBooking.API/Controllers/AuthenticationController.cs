using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PlaneBooking.Database.ViewModels;

namespace PlaneBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        [Route("register/{userName}/{password}")]
        [HttpPost]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> InsertUser(string userName, string password, string role = null)
        {
            var user = new IdentityUser
            {
                UserName = userName,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, string.IsNullOrEmpty(role) ? "NormalUser" : "Administrator");
            }
            return Ok(user);
        }

        [Route("login/{userName}/{password}")]
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            try
            {
                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {
                    var claim = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
                };
                    var signinKey = new SymmetricSecurityKey(
                      Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                    int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                    var token = new JwtSecurityToken(
                      issuer: _configuration["Jwt:Site"],
                      audience: _configuration["Jwt:Site"],
                      expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                      signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(
                      new
                      {
                          token = new JwtSecurityTokenHandler().WriteToken(token),
                          expiration = token.ValidTo
                      });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Authentication { ex.Message }");
            }

            return Unauthorized();
        }
    }
}