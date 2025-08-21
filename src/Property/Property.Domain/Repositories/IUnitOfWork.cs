using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IPropertyRepository Properties { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
