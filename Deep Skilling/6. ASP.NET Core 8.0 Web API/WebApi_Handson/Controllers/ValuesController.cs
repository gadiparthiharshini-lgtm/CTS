using Microsoft.AspNetCore.Mvc;

namespace WebApi_Handson.Controllers;

// Hands-on 1: the default "Values" controller created by the API template,
// with Read (GET) and Write (POST/PUT/DELETE) actions that map to the HTTP
// action verbs. A controller inherits from ControllerBase and is marked with
// [ApiController] (the .NET Core equivalent of the old ApiController base).
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        return $"value{id}";
    }

    // POST api/values
    [HttpPost]
    public IActionResult Post([FromBody] string value)
    {
        return Ok(value);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] string value)
    {
        return NoContent();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
