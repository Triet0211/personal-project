using BusinessObject;
using System.Collections.Generic;


namespace DataAccess.Repository
{
    public interface IPublisherRepository
    {
        IEnumerable<Publisher> GetPublishers();
        void CreateNewPublisher(Publisher pub);
        void UpdatePublisher(Publisher pub);
        void DeletePublisher(int id);
    }
}