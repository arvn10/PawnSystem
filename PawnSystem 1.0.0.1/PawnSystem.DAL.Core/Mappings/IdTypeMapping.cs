using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

using IdType = PawnSystem.DAL.Data.Entities.IdType;

namespace PawnSystem.DAL.Core.Mappings
{
    public class IdTypeMapping : EntityTypeConfiguration<IdType>
    {
        public IdTypeMapping()
        {
            this.ToTable("IdType")
                .HasKey(x => x.ID);
            this.Property(p => p.Type).HasColumnName("Type");
            this.Property(p => p.CreatedBy).HasColumnName("CreatedBy");
            this.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
            this.Property(p => p.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
