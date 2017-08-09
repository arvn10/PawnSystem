using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnSystem.BLL.Service
{
    public abstract class CrudService<T>
    {
        public abstract IQueryable<T> Get();

        public abstract T Create(T model);

        public abstract T Update(T model);

        public abstract bool Delete(T model);
    }
}
