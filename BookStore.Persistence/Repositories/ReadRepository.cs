using BookStore.Application.Repositories;
using BookStore.Domain.Entities.Common;
using BookStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking)
              query=  query.AsNoTracking();
            return query;
        }
        //public IQueryable<T> Get(Expression<Func<T, bool>> method, bool tracking = true,params Expression<Func<T,object>>[] includes) {
        // var query = Table.AsQueryable();
        //    if (method != null) 
        //        query = query.Where(method);
        //    query= ApplyIncludes(query, includes);
        //    if(tracking)
        //        query= query.AsNoTracking();
        //    return query;
        //}
        public static IQueryable<T> ApplyIncludes(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            {
            if (includes != null)
            {
                foreach (var includeItem in includes)
                {
                    query = query.Include(includeItem);
                }
            }
            return query;
        }


        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        { 
        var query =Table.AsQueryable();
            if(!tracking)
                query= query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        { 
            var query = Table.Where(method);
            if(!tracking)
                query = query.AsNoTracking();
            return query;
        
        }
    }
}
