using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using Client = PawnSystem.DAL.Data.Entities.Client;
namespace PawnSystem.DAL.Core.Mappings
{
    public class ClientMapping : EntityTypeConfiguration<Client>
    {
        public ClientMapping()
        {
            this.ToTable("Client")
                .HasKey(x => x.ID);

            this.Property(p => p.FirstName).HasColumnName("FirstName");
            this.Property(p => p.LastName).HasColumnName("LastName");
            this.Property(p => p.Address).HasColumnName("Address");
            this.Property(p => p.ContactNumber).HasColumnName("ContactNumber");
            this.Property(p => p.ImagePath).HasColumnName("ImagePath");
            this.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            this.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            this.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
