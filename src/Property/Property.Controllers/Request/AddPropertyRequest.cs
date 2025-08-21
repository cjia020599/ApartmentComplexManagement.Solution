using System.ComponentModel.DataAnnotations;

namespace Property.Controllers.Request
{
    public class AddPropertyRequest
    {
        [Required]
        public string Unit { get; set; } = null!;
        
    }
}
