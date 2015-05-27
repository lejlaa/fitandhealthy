using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy.Mappers
{
    class TrainingMap : EntityTypeConfiguration<Training>
    {
        public TrainingMap()
        {
            this.ToTable("Trainings");
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasColumnName("Id").IsRequired();
            this.Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(40);
            this.Property(p => p.Description).HasColumnName("Description").IsRequired().HasMaxLength(100);
            this.Property(p => p.Rating).HasColumnName("Rating");
            this.Property(p => p.RatedByNo).HasColumnName("RatedByNo");
            this.Property(p => p.Video).HasColumnName("VideoLink");
        }
    }
}
