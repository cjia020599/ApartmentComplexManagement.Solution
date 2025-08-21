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
            PropertyResponse property = await _commands.AddPropertyAsync(request.Unit, HttpContext.RequestAborted);
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
        public async Task<IActionResult> GetVacantProperties()
        {
            List<PropertyResponse> property = await _queries.GetAllVacantProperties();
            return Ok(property);
        }
        [HttpGet("/getAllOccupied")]
        public async Task<IActionResult> GetOccupiedProperties()
        {
            List<PropertyResponse> property = await _queries.GetAllOccupiedProperties();
            return Ok(property);
        }
        [HttpGet("/getAllUnderMaintenance")]
        public async Task<IActionResult> GetUnderMaintenanceProperties()
        {
            List<PropertyResponse> property = await _queries.GetAllUnderMaintenanceProperties();
            return Ok(property);
        }
        [HttpPost("/vancantUnit")]
        public async Task<IActionResult> VacantUnit(string unit)
        {
            var property = await _commands.VacantPropertyAsync(unit, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetProperties), new { id = property }, property);
        }
        [HttpPost("/occupyUnit")]
        public async Task<IActionResult> OccupyUnit(string unit)
        {
            var property = await _commands.OccupyPropertyAsync(unit, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetProperties), new { id = property }, property);
        }
        [HttpPost("/underMaintenanceUnit")]
        public async Task<IActionResult> UnderMaintainanceUnit(string unit)
        {
            var property = await _commands.UnderMaintenancePropertyAsync(unit, HttpContext.RequestAborted);
            return CreatedAtAction(nameof(GetProperties), new { id = property }, property);
        }
    }
}
