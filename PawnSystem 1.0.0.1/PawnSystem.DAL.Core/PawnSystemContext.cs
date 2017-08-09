using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using PawnSystem.DAL.Core.Mappings;

namespace PawnSystem.DAL.Core
{
    public class PawnSystemContext : DbContext
    {
        public PawnSystemContext() : base("name=PawnSystem.Connection"){}

        #region Method(s)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuctionDateMapping());
            modelBuilder.Configurations.Add(new ClientMapping());
            modelBuilder.Configurations.Add(new ItemTypeMapping());
            modelBuilder.Configurations.Add(new TransactionItemMapping());
            modelBuilder.Configurations.Add(new TransactionMapping());
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserTypeMapping());
            modelBuilder.Configurations.Add(new IdTypeMapping());
            modelBuilder.Configurations.Add(new TicketTypeMapping());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region DBContext                
        public IQueryable<T> AsQueryable<T>() where T : class
        {
            return this.Set<T>();
        }

        public T Add<T>(T item) where T : class
        {
            this.Set<T>().Add(item);
            return item;
        }

        public T Remove<T>(T item) where T : class
        {
            this.Set<T>().Remove(item);
            return item;
        }

        public T Update<T>(T item) where T : class
        {
            var entry = this.Entry(item);

            if (entry != null)
            {
                entry.CurrentValues.SetValues(item);
            }
            else
            {
                this.Attach(item);
            }

            return item;
        }

        public T Attach<T>(T item) where T : class
        {
            this.Set<T>().Attach(item);
            return item;
        }

        public T Detach<T>(T item) where T : class
        {
            this.Entry(item).State = EntityState.Detached;
            return item;
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public void ExecuteTSQL(string tsql)
        {
            base.Database.ExecuteSqlCommand(tsql);
            base.SaveChanges();
        }

        public T GetColumn<T>(string tsql)
        {
            return base.Database.SqlQuery<T>(tsql).FirstOrDefault<T>();
        }

        public List<T> GetList<T>(string tsql) where T : class
        {
            return base.Database.SqlQuery<T>(tsql).ToList();
        }
        #endregion
    }
}
