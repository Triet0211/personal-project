using BusinessObject;
using DataAccess.DAO;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        public void CreateNewPublisher(Publisher pub) => PublisherDAO.Instance.CreateNewPublisher(pub);
        public void UpdatePublisher(Publisher pub) => PublisherDAO.Instance.UpdatePublisher(pub);
        public void DeletePublisher(int id) => PublisherDAO.Instance.RemovePublisher(id);

        public IEnumerable<Publisher> GetPublishers() => PublisherDAO.Instance.GetPublisherList();
    }
}
