using Microsoft.AspNetCore.Mvc;

namespace recipe_service.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;

    public RecipeController(ILogger<RecipeController> logger)
    {
        _logger = logger;
    }


    [HttpGet("/Recipes/{id:int}")]
    [Produces("application/json")]
    public IActionResult GetRecipe(int id)
    {
        // @TODO: fetch from data access
        return Ok("{a: 20}");
        //return NotFound();
    }

    [HttpPost("/Recipes")]
    [Produces("application/json")]
    public IActionResult AddRecipe([FromBody] string recipe)
    {
        // @TODO: create new via. data access
        string url = Url.Action("GetRecipe", "Recipe", new { id = 1 })!; // @TODO: get recipeID
        return Created(url, "{id: 1, value:5}");                         // @TODO: get added recipe
    }

    [HttpDelete("/Recipes/{id:int}")]
    public IActionResult DeleteRecipe(int id)
    {
        // @TODO: delete from db
        // @TODO: user validation
        return Ok();
        //return NotFound();
    }

    [HttpPut("/Recipes/{id:int}")]
    public IActionResult UpdateRecipe(int id, [FromBody] string recipe)
    {
        // @TODO: update entry in db
        // @TODO: user validation
        return Ok();
        //return NotFound();
    }
}