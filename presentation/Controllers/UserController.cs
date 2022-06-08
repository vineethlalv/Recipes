using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using recipe_service.Application.Interfaces;
using recipe_service.Application.Constants;
using recipe_service.Application.DTOs;

namespace recipe_service.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserManager _userManager;

    public UserController(ILogger<UserController> logger, IUserManager userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }


    [AllowAnonymous]
    [HttpPost("/Users")]
    public IActionResult AddUser([FromBody] UserModel userDetails)
    {
        UserStatus status = _userManager.AddUser(userDetails);
        switch(status)
        {
            case UserStatus.InvalidInputs:
                return NoContent();
            case UserStatus.UserNameExists:
                return Conflict("User with same username exists");
            case UserStatus.PWPolicyViolation:
                return Forbid("Password doesn't conform to policy");
            default:
                return Ok();
        }
    }

    [AllowAnonymous]
    [HttpPost("/Users/Login")]
    public IActionResult UserLogin([FromBody] UserModel login)
    {
        var user = _userManager.Authenticate(login.UserName, login.PassWord);
        if(user != null)
        {
            return Ok(new { token = _userManager.GenerateToken(user) });
        }
        return Forbid();
    }

    [HttpPost("/Users/Logoff")]
    public IActionResult UserLogoff()
    {
        // @TODO: research/figure out methods for JWT server invalidation
        return Ok();
        // return Forbid();
    }

    [HttpDelete("/Users")]
    public IActionResult UserDelete()
    {
        // @TODO: only when user is logged in already
        // @TODO: verify password from from request body
        // @TODO: logout user - if success
        return Ok();
        // return Forbid();
    }
}