using Property.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PropertyDbContext _context;
        private readonly IPropertyRepository _propertyRepository;

        public UnitOfWork(PropertyDbContext context, IPropertyRepository propertyRepository)
        {
            _context = context;
            _propertyRepository = propertyRepository;
        }
        public IPropertyRepository Properties => _propertyRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
