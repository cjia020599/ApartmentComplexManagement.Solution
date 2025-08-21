using Property.Domain.Entities;

namespace Property.Domain.Services
{
    public class ChangeStatusService
    {
        public PropertyUnit OccupyProperty(PropertyUnit property)
        {
            property.Update(property.Unit, "Occupied");
            return property;
        }
        public PropertyUnit VacantProperty(PropertyUnit property)
        {
            property.Update(property.Unit, "Vacant");
            return property;
        }
        public PropertyUnit UnderMaintenanceProperty(PropertyUnit property)
        {
            property.Update(property.Unit, "Under Maintenance");
            return property;
        }
    }
}
