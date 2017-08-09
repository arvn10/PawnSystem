using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using TicketType = PawnSystem.DAL.Data.Entities.TicketType;
namespace PawnSystem.DAL.Core.Mappings
{
    public class TicketTypeMapping : EntityTypeConfiguration<TicketType>
    {
        public TicketTypeMapping()
        {
            this.ToTable("TicketType")
                .HasKey(x => x.ID);

            this.Property(p => p.ID).HasColumnName("ID");
            this.Property(p => p.Type).HasColumnName("TicketType");
            this.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            this.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            this.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
