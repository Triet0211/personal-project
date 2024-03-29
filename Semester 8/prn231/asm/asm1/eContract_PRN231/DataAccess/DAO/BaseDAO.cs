﻿using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class BaseDAO<T> where T : class
    {
        private readonly eRecruitmentContext _dbContext;
        internal DbSet<T> dbSet;

        public BaseDAO()
        {
            _dbContext = new eRecruitmentContext();
            this.dbSet = _dbContext.Set<T>();
        }

        public void Add(T t)
        {
            dbSet.Add(t);
            _dbContext.SaveChanges();
        }

        public T Get(int Id)
        {
            return dbSet.Find(Id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

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

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null, T defaultValue = null)
        {
            IQueryable<T> query = dbSet;

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

            return query.Count() == 0 ? defaultValue : query.First();
        }


        public void Remove(T t)
        {
            dbSet.Remove(t);
            _dbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            T deletedDto = dbSet.Find(id);
            if (deletedDto != null)
            {
                dbSet.Remove(deletedDto);
            }
        }

        public void RemoveRange(IEnumerable<T> t)
        {
            dbSet.RemoveRange(t);
            _dbContext.SaveChanges();
        }
    }

}
