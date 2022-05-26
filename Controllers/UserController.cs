using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using recipe_service.Models;

namespace recipe_service.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly ILoginManager _loginManager;

    public UserController(ILogger<UserController> logger, ILoginManager loginManager)
    {
        _logger = logger;
        _loginManager = loginManager;
    }


    [AllowAnonymous]
    [HttpPost("/Users")]
    public IActionResult AddUser()
    {
        // @TODO: validations - unique username, password constraints
        // @TODO: add user to db
        return Ok();
        // return Conflict();    // @TODO: on same username
        // return Forbid();      // @ TODO: on password policy violation
    }

    [AllowAnonymous]
    [HttpPost("/Users/Login")]
    public IActionResult UserLogin([FromBody] UserModel login)
    {
        var user = _loginManager.Authenticate(login.UserName, login.PassWord);
        if(user != null)
        {
            return Ok(new { token = _loginManager.GenerateToken(user) });
        }
        return Forbid();
    }

    [HttpPost("/Users/Logoff")]
    public IActionResult UserLogoff()
    {
        // @TODO: only when user is logged in
        // @TODO: logoff user
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