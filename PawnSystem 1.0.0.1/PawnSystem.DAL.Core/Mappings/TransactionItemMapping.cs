using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using TransactionItem = PawnSystem.DAL.Data.Entities.TransactionItem;
namespace PawnSystem.DAL.Core.Mappings
{
    public class TransactionItemMapping : EntityTypeConfiguration<TransactionItem>
    {
        public TransactionItemMapping()
        {
            this.ToTable("TransactionItem")
                .HasKey(x => x.ID);

            this.Property(p => p.ID).HasColumnName("ID");
            this.Property(p => p.Description).HasColumnName("Description");
            this.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            this.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            this.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");

            this.HasRequired(x => x.Transaction)
                .WithMany(x => x.TransactionItem)
                .HasForeignKey(x => x.TransactionID);
                
        }
    }
}
