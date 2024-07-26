using Microsoft.AspNetCore.Mvc;

namespace SoulKingWebAPI.Controllers
{
  [Route("api")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    [HttpPut("hello")]
    public async Task<ActionResult<string>> SayHello([FromBody]string Name)
    {
      return Ok($"Hello, {Name}!");
    }
  }
}
