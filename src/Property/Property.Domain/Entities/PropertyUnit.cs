using Property.Domain.Exceptions;
using Property.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Entities
{
    public class PropertyUnit
    {
        public PropertyId Id { get; private set; } = null!;
        public string Unit { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string? OWner { get; set; }
        public string? Tenant { get; set; }

        protected PropertyUnit() { }

        public static PropertyUnit Create(string unit)
        {
            return new PropertyUnit
            {
                Id = new PropertyId(Guid.NewGuid()),
                Unit = unit,
                Status = "Vacant"
            };
        }
        public void Update(string unit, string status)
        {
            if (string.IsNullOrWhiteSpace(unit))
            {
                throw new ArgumentException("Status cannot be null or empty.", nameof(unit));
            }
            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Status cannot be null or empty.", nameof(status));
            }
            if (status == "Vacant" || status == "Occupied" || status == "Under maintenance")
            {
                Unit = unit;
                Status = status;
                return;
            }
            throw new ArgumentException("Invalid Status. Status must be either 'Vacant', 'Occupied', or 'Under Maintenance'.", status);
        }
    }
}
