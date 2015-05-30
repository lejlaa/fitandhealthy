using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy.Mappers
{
    class CommentMap: EntityTypeConfiguration<Comment> 
    {
        public CommentMap()        
         {             
             this.ToTable("Comments");             
             this.HasKey(p => p.Id);  
             this.Property(p => p.Id).HasColumnName("Id").IsRequired();             
  
            this.Property(p => p.Rating).HasColumnName("Rating");
             this.Property(p => p.RatedByNo).HasColumnName("RatedByNo");
            this.Property(p => p.CommentText).HasColumnName("Comment").HasMaxLength(100);
         }   
    }
}
