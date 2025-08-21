using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;
using Property.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infrastructure.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyDbContext _context;

        public PropertyRepository(PropertyDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(PropertyUnit propertyUnit)
        {
            await _context.Properties.AddAsync(propertyUnit);
        }

        public async Task DeleteAsync(PropertyUnit propertyUnit)
        {
            _context.Properties.Remove(propertyUnit);
        }

        public async Task<List<PropertyUnit>> GetAllAsync()
        {
            return await _context.Properties.ToListAsync();
        }

        public async Task UpdateAsync(PropertyUnit propertyUnit)
        {
             _context.Properties.Update(propertyUnit);
        }
    }
}
