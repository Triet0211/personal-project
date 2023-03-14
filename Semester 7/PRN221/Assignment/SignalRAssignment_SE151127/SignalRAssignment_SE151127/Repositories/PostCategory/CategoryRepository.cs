using SignalRAssignment_SE151127.DataAccess;
using SignalRAssignment_SE151127.Models;
using System.Collections.Generic;
using System.Linq;

namespace SignalRAssignment_SE151127.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private CategoryDAO _categoryDao;

        public CategoryRepository(CategoryDAO categoryDao)
        {
            _categoryDao = categoryDao;
        }
        public IEnumerable<PostCategory> GetAll()
        {
            return _categoryDao.GetAll();
        }

        public PostCategory GetById(int id)
        {
            return _categoryDao.Get(id);
        }
    }
}
