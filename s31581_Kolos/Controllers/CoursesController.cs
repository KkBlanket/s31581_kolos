using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using s31581_Kolos.Exceptions;
using s31581_Kolos.Services;

namespace s31581_Kolos.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CoursesController(IDbService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        try
        {
            return Ok(await service.GetAllCourses());
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (DbException e)
        {
            return StatusCode(500, e.Message);
        }
    }
}