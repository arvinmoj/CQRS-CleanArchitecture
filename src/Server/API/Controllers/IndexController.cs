using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class IndexController : ControllerBase
{
    public IndexController() : base()
    {
    }

    [HttpGet(Name = "Get")]
    public IActionResult Get()
    {
        return Ok(value: "Index Controller - Action Get");
    }

}
