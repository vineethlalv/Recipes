using Microsoft.AspNetCore.Mvc;

namespace recipe_service.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeSearchController : ControllerBase
{
    private readonly ILogger<RecipeSearchController> _logger;

    public RecipeSearchController(ILogger<RecipeSearchController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/Recipies/Search")]
    [Produces("application/json")]
    public IActionResult Search([FromQuery(Name = "q")] string searchText)
    {
        // @TODO: search data access with searchText
        return Ok("{a: 20}");
    }
}