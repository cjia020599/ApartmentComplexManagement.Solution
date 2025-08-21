using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Response
{
    public class PropertyResponse
    {
        public Guid Id { get; set; }
        public string Unit { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
