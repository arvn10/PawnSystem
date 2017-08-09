using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using AuctionDate = PawnSystem.DAL.Data.Entities.AuctionDate;
namespace PawnSystem.DAL.Core.Mappings
{
    public class AuctionDateMapping : EntityTypeConfiguration<AuctionDate>
    {
        public AuctionDateMapping()
        {
            this.ToTable("AuctionDate")
                .HasKey(x => x.ID);

            this.Property(p => p.Date).HasColumnName("Date");
            this.Property(p => p.ItemFrom).HasColumnName("ItemFrom");
            this.Property(p => p.ItemTo).HasColumnName("ItemTo");
            this.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            this.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            this.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");

        }
    }
}
