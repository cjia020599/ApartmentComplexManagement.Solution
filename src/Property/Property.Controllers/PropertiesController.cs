using Microsoft.AspNetCore.Mvc;
using Property.Application.Commands;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Controllers.Request;

namespace Property.Controllers
{
    [Route("api/property")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyCommands _commands;
        private readonly IPropertyQueries _queries;

        public PropertiesController(IPropertyCommands commands, IPropertyQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        [HttpPost("/add")]
        public async Task<IActionResult> AddProperty([FromBody] AddPropertyRequest request)
        {
            PropertyResponse property = await _commands.AddPropertiesAsync(request.Unit, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetProperties), new { id = property.Id }, property);
        }
        [HttpDelete("/delete")]
        public async Task<IActionResult> DeleteProperty(string name)
        {
            var result = await _commands.DeletePropertyAsync(name, HttpContext.RequestAborted);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors.First().Message);
            }
            return NoContent();
        }
        [HttpGet("/getAll")]
        public async Task<IActionResult> GetProperties(string? name)
        {
            PropertyResponse? property = await _queries.GetPropertyByUnitAsync(name);
            if (property == null)
            {
                var properties = await _queries.GetAllPropertiesAsync();
                return Ok(properties);
            }
            return Ok(property);
        }
        [HttpGet("/getAllVacants")]
        public async Task<IActionResult> GetVacantProperties(string? name)
        {
            PropertyResponse? property = await _queries.GetPropertyByUnitAsync(name);
            if (property == null)
            {
                var properties = await _queries.GetAllPropertiesAsync();
                return Ok(properties);
            }
            return Ok(property);
        }
        [HttpGet("/getAllOccupied")]
        public async Task<IActionResult> GetOccupiedProperties(string? name)
        {
            PropertyResponse? property = await _queries.GetPropertyByUnitAsync(name);
            if (property == null)
            {
                var properties = await _queries.GetAllPropertiesAsync();
                return Ok(properties);
            }
            return Ok(property);
        }
        [HttpGet("/getAllUnderMaintenance")]
        public async Task<IActionResult> GetUnderMaintenanceProperties(string? name)
        {
            PropertyResponse? property = await _queries.GetPropertyByUnitAsync(name);
            if (property == null)
            {
                var properties = await _queries.GetAllPropertiesAsync();
                return Ok(properties);
            }
            return Ok(property);
        }
    }
}
