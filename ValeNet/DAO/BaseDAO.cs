using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeNet.Data;
using ValeNet.Models;

namespace ValeNet.DAO
{
    public abstract class BaseDAO<T> where T : BaseModel
    {
        protected readonly ApplicationDbContext contexto;
        protected readonly DbSet<T> dbSet;

        public BaseDAO(ApplicationDbContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
    }
}
