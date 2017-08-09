using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using UserType = PawnSystem.DAL.Data.Entities.UserType;
namespace PawnSystem.DAL.Core.Mappings
{
    public class UserTypeMapping : EntityTypeConfiguration<UserType>
    {
        public UserTypeMapping()
        {
            this.ToTable("UserType")
                .HasKey(x => x.ID);

            this.Property(p => p.Type).HasColumnName("Type");
            this.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            this.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            this.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");

        }
    }
}
