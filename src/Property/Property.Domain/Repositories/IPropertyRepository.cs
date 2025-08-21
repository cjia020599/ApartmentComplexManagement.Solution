using Property.Domain.Entities;

namespace Property.Domain.Repositories
{
    public interface IPropertyRepository
    {
        Task<List<PropertyUnit>> GetAllAsync();
        Task AddAsync(PropertyUnit propertyUnit);
        Task DeleteAsync(PropertyUnit propertyUnit);
        Task UpdateAsync(PropertyUnit propertyUnit);
    }
}
