using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitAndHealthy.Mappers
{
    class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("Users");
            this.HasKey(p => p.Id);
            this.Property(p => p.Id).HasColumnName("Id").IsRequired();
            this.Property(p => p.Username).HasColumnName("Username").IsRequired().HasMaxLength(40);
            this.Property(p => p.Banned).HasColumnName("Banned").IsRequired();
            this.Property(p => p.Password).HasColumnName("Password").IsRequired();
            this.Property(p => p.Email).HasColumnName("Email").IsRequired();
            this.Property(p => p.ConfirmationToken).HasColumnName("ConfirmationToken").IsRequired();
            this.Property(p => p.ConfirmedUser).HasColumnName("ConfirmedUser").IsRequired();


        }
    }
}
