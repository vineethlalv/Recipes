using Microsoft.AspNetCore.Mvc;

namespace recipe_service.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }


    [HttpPost("/Users")]
    public IActionResult AddUser()
    {
        // @TODO: validations - unique username, password constraints
        // @TODO: add user to db
        return Ok();
        // return Conflict();    // @TODO: on same username
        // return Forbid();      // @ TODO: on password policy violation
    }

    [HttpPost("/Users/Login")]
    public IActionResult UserLogin()
    {
        // @TODO: do credential check
        // @TODO: access token 
        return Ok();
        // return Forbid();
    }

    [HttpPost("/Users/Logoff")]
    public IActionResult UserLogoff()
    {
        // @TODO: only when user is logged in
        // @TODO: logoff user
        return Ok();
        // return Forbid();
    }

    [HttpDelete("/Users/Delete")]
    public IActionResult UserDelete()
    {
        // @TODO: only when user is logged in already
        // @TODO: verify password from from request body
        // @TODO: logout user - if success
        return Ok();
        // return Forbid();
    }
}