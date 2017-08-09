using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using Transaction = PawnSystem.DAL.Data.Entities.Transaction;
namespace PawnSystem.DAL.Core.Mappings
{
    public class TransactionMapping : EntityTypeConfiguration<Transaction>
    {
        public TransactionMapping()
        {
            this.ToTable("Transaction")
                .HasKey(x => x.ID);

            this.Property(p => p.OldTransactionID).HasColumnName("OldTransactionID");
            this.Property(p => p.ClientID).HasColumnName("ClientID");
            this.Property(p => p.ItemTypeID).HasColumnName("ItemTypeID");
            this.Property(p => p.AuctionDateID).HasColumnName("AuctionDateID");
            this.Property(p => p.IdTypeID).HasColumnName("IdTypeID");
            this.Property(p => p.TicketTypeID).HasColumnName("TicketTypeID");
            this.Property(p => p.PawnTicketNumber).HasColumnName("PawnTicketNumber");
            this.Property(p => p.TransactionType).HasColumnName("TransactionType");
            this.Property(p => p.DateLoan).HasColumnName("DateLoan");
            this.Property(p => p.DateMaturity).HasColumnName("DateMaturity");
            this.Property(p => p.DateExpiry).HasColumnName("DateExpiry");
            this.Property(p => p.DatePenalty).HasColumnName("DatePenalty");
            this.Property(p => p.Principal).HasColumnName("Principal");
            this.Property(p => p.Interest).HasColumnName("Interest");
            this.Property(p => p.ServiceCharge).HasColumnName("ServiceCharge");
            this.Property(p => p.Penalty).HasColumnName("Penalty");
            this.Property(p => p.AppraiseValue).HasColumnName("AppraiseValue");
            this.Property(p => p.NetProceed).HasColumnName("NetProceed");
            this.Property(p => p.Status).HasColumnName("Status");
            this.Property(p => p.DateClosed).HasColumnName("DateClosed");
            this.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            this.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            this.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");

            #region Client Mapping

            this.HasRequired(x => x.Client)
                .WithMany(x => x.Transaction)
                .HasForeignKey(x => x.ClientID);

            #endregion

            #region ItemType Mapping

            this.HasRequired(x => x.ItemType)
                .WithMany(x => x.Transaction)
                .HasForeignKey(x => x.ItemTypeID);

            #endregion

            #region AuctionDate Mapping

            this.HasRequired(x => x.AuctionDate)
                .WithMany(x => x.Transaction)
                .HasForeignKey(x => x.AuctionDateID);

            #endregion

            #region IdType Mapping

            this.HasRequired(x => x.IdType)
                .WithMany(x => x.Transaction)
                .HasForeignKey(x => x.IdTypeID);
            #endregion

            #region TicketType Mapping

            this.HasRequired(x => x.TicketType)
                .WithMany(x => x.Transaction)
                .HasForeignKey(x => x.TicketTypeID);
            #endregion
        }
    }
}
