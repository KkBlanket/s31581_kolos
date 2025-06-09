using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using s31581_Kolos.DTO_s;
using s31581_Kolos.Exceptions;
using s31581_Kolos.Services;

namespace s31581_Kolos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(IDbService service) : ControllerBase
{
    [HttpPost("with-enrollments")]
    public async Task<IActionResult> CreateStudent([FromBody] StudentCreateDto studentCreateDto)
    {
        try
        {
            return Ok(await service.CreateStudent(studentCreateDto));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (DbException e)
        {
            return StatusCode(500,e.Message);
        }
    }
}