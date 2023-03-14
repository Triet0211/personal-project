
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment_SE151127.Models;

namespace SignalRAssignment_SE151127.DataAccess
{
    public class BaseDAO<TDto> where TDto : class
    {
        private readonly ApplicationDBContext _dbContext;
        internal DbSet<TDto> dbSet;

        public BaseDAO(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            this.dbSet = _dbContext.Set<TDto>();
        }

        public void Add(TDto dto)
        {
            dbSet.Add(dto);
        }

        public TDto Get(int Id)
        {
            return dbSet.Find(Id);
        }

        public IQueryable<TDto> GetAll(Expression<Func<TDto, bool>> filter = null, Func<IQueryable, IOrderedQueryable<TDto>> orderBy = null, string includeProperties = null)
        {
            IQueryable<TDto> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includedProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includedProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;

        }

        public TDto GetFirstOrDefault(Expression<Func<TDto, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<TDto> query = dbSet;

            if (includeProperties != null)
            {
                foreach (var includedProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includedProp);
                }
            }

            if (filter != null)
            {
                return query.FirstOrDefault(filter);
            }

            return query.FirstOrDefault();

        }

        public void Remove(TDto dto)
        {
            dbSet.Remove(dto);
        }

        public void Remove(int id)
        {
            TDto deletedDto = dbSet.Find(id);
            if (deletedDto != null)
            {
                dbSet.Remove(deletedDto);
            }
        }

        public void RemoveRange(IEnumerable<TDto> dto)
        {
            dbSet.RemoveRange(dto);
        }
    }
}
