using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy.Mappers
{
    class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap () {
            this.ToTable("Categories");
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasColumnName("Id").IsRequired();
            this.Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(40);
           
        }
    }
}
