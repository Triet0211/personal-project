using SignalRAssignment_SE151127.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SignalRAssignment_SE151127.UnitOfWork
{
    public class UnitOfWorkFactory
    {
        public UnitOfWork Get { get { return new UnitOfWork(new ApplicationDBContext()); } }

        public IDisposable UnitOfWork { get; set; }
    }
}
