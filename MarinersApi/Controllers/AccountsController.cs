using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MarinersApi.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace MarinersApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto user)
    {
        var userExists = await _userManager.FindByEmailAsync(user.Email);
        if (userExists != null)
        {
            return BadRequest(new { status = "error", message = "Email already exists " });
        }

        var newUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
        var result = await _userManager.CreateAsync(newUser, user.Password);
        if (result.Succeeded)
        {
            return Ok(new { status = "success", message = "user has been successfully created" });
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }

    [HttpPost("signIn")]
    public async Task<IActionResult> SignIn(SignInDto userInfo)
    {
        IdentityUser user = await _userManager.FindByEmailAsync(userInfo.Email);
        if (user != null)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(user, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                var authClaims = new List<Claim>
                {
                    new Claim("UserId", user.Id)
                };

                var newToken = CreateToken(authClaims);

                return Ok(new { status = "success", message = $"{userInfo.Email} signed in", token = newToken });
            }
        }
        return BadRequest(new { status = "error", message = "Unable to sign in" });
    }

    private string CreateToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}