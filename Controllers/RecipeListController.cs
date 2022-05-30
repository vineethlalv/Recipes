using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace recipe_service.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class RecipeListController : ControllerBase
{
    private readonly ILogger<RecipeListController> _logger;

    public RecipeListController(ILogger<RecipeListController> logger)
    {
        _logger = logger;
    }


    [AllowAnonymous]
    [HttpGet("/Recipies/Lists/{id:int}")]
    [Produces("application/json")]
    public IActionResult GetRecipeList(int id)
    {
        // @TODO: get list from db
        // @TODO: user validation - private/public list
        return Ok("[{a: 20}, {a: 21, b: '50'}]");
        //return NotFound();
    }

    [HttpPost("/Recipies/Lists/")]
    [Produces("application/json")]
    public IActionResult CreateRecipeList([FromBody] string recipeList)
    {
        // @TODO: add list to db
        string url = Url.Action("GetRecipeList", "Recipe", new { id = 1 })!;   // @TODO: get recipeListID
        return Created(url, "{id: 1, value:5}");                               // @TODO: get added recipeList
    }

    [HttpDelete("/Recipies/Lists/{id:int}")]
    [Produces("application/json")]
    public IActionResult DeleteRecipeList(int id)
    {
        // @TODO: delete list from db
        // @TODO: user list ownership validation
        return Ok();
        //return NotFound();
    }

    [HttpPut("/Recipies/Lists/{lID:int}/{rID:int}")]
    public IActionResult AddToRecipeList(int lID, int rID)
    {
        // @TODO: update list in db
        // @TODO: user validation for ownership
        return Ok();
        //return NotFound();
    }

    [HttpDelete("/Recipies/Lists/{lID:int}/{rID:int}")]
    public IActionResult RemoveFromRecipeList(int lID, int rID)
    {
        // @TODO: update list in db
        // @TODO: user validation for ownership
        return Ok();
        //return NotFound();
    }

    [HttpGet("/Recipies/Lists/Favourites")]
    [Produces("application/json")]
    public IActionResult GetFavourites()
    {
        // @TODO: only when user is logged in already
        // @TODO: get list from db
        return Ok("[{a: 20}, {a: 21, b: '50'}]");
        //return Forbid();
    }

    [HttpPut("/Recipies/Lists/Favourites/{rID:int}")]
    public IActionResult AddToFavourites(int rID)
    {
        // @TODO: only when user is logged in already
        // @TODO: update list in db
        return Ok();
        //return NotFound();
    }

    [HttpDelete("/Recipies/Lists/Favourites/{rID:int}")]
    public IActionResult RemoveFromFavourites(int rID)
    {
        // @TODO: only when user is logged in already
        // @TODO: update list in db
        return Ok();
        //return NotFound();
    }
}