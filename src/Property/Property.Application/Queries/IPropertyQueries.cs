using Property.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Queries
{
    public interface IPropertyQueries
    {
        Task<PropertyResponse?> GetPropertyByUnitAsync(string? unit);
        Task<List<PropertyResponse>> GetAllPropertiesAsync();
        Task<List<PropertyResponse>> GetAllVacantProperties();
        Task<List<PropertyResponse>> GetAllOccupiedProperties();
        Task<List<PropertyResponse>> GetAllUnderMaintenanceProperties();
    }
}
