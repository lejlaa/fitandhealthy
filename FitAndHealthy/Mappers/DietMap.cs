using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy.Mappers 
{
    class DietMap : EntityTypeConfiguration<Diet>
    {
        public DietMap() { 
             this.ToTable("Diets");             
             this.HasKey(p => p.Id);  
             this.Property(p => p.Id).HasColumnName("Id").IsRequired();             
             this.Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(40);
             this.Property(p => p.Description).HasColumnName("Description").IsRequired().HasMaxLength(100);
             this.Property(p => p.Rating).HasColumnName("Rating");
             this.Property(p => p.RatedByNo).HasColumnName("RatedByNo");
            
    }
} 
}
