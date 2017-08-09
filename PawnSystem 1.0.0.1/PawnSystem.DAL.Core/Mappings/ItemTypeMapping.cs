using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using ItemType = PawnSystem.DAL.Data.Entities.ItemType;
namespace PawnSystem.DAL.Core.Mappings
{
    public class ItemTypeMapping : EntityTypeConfiguration<ItemType>
    {
        public ItemTypeMapping()
        {
            this.ToTable("ItemType")
                .HasKey(x => x.ID);

            this.Property(p => p.Description).HasColumnName("Description");
            this.Property(p => p.Interest).HasColumnName("Interest");
            this.Property(p => p.Penalty).HasColumnName("Penalty");
            this.Property(p => p.AppraiseValue).HasColumnName("AppraiseValue");
            this.Property(p => p.WithServiceCharge).HasColumnName("WithServiceCharge");
            this.Property(p => p.DaysToMature).HasColumnName("DaysToMature");
            this.Property(p => p.DaysToPenalty).HasColumnName("DaysToPenalty");
            this.Property(p => p.DaysToExpire).HasColumnName("DaysToExpire");
            this.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            this.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            this.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");

        }
    }
}
