using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infrastructure.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<PropertyUnit>
    {
        public void Configure(EntityTypeBuilder<PropertyUnit> property)
        {
            property.HasKey(p => p.Id);
            property.Property(p => p.Id)
                .HasConversion(id => id.Value, value => new PropertyId(value));
        }
    }
}
