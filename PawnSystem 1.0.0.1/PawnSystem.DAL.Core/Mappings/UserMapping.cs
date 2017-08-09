using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using User = PawnSystem.DAL.Data.Entities.User;
namespace PawnSystem.DAL.Core.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.ToTable("User")
                .HasKey(x => x.ID);

            this.Property(p => p.UserTypeID).HasColumnName("UserTypeID");
            this.Property(p => p.UserName).HasColumnName("UserName");
            this.Property(p => p.Password).HasColumnName("Password");
            this.Property(p => p.FirstName).HasColumnName("FirstName");
            this.Property(p => p.LastName).HasColumnName("LastName");
            this.Property(p => p.Status).HasColumnName("Status");
            this.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            this.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            this.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");

            #region UserType Mapping

            this.HasRequired(x => x.UserType)
                .WithMany(x => x.User)
                .HasForeignKey(x => x.UserTypeID);

            #endregion
        }
    }
}
