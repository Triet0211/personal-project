using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class PublisherDAO
    {
        //Using Singleton Pattern
        private static PublisherDAO instance = null;
        private static readonly object instanceLock = new object();
        private PublisherDAO() { }
        public static PublisherDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PublisherDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Publisher> GetPublisherList()
        {
            var publishers = new List<Publisher>();
            try
            {
                using var context = new BookStoreContext();
                publishers = context.Publishers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return publishers;
        }

        public void CreateNewPublisher(Publisher publisher)
        {
            try
            {
                using var context = new BookStoreContext();
                context.Add(publisher);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdatePublisher(Publisher publisher)
        {
            try
            {
                using var context = new BookStoreContext();
                context.Update(publisher);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RemovePublisher(int id)
        {
            try
            {
                using var context = new BookStoreContext();
                Publisher pub = context.Publishers.FirstOrDefault(e => e.PubId == id);
                if (pub == null)
                {
                    throw new Exception("Publisher not found!");
                }
                context.Publishers.Remove(pub);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
