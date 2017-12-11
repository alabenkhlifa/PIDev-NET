using Data.Infrastructure;
using Domain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public class CollectService : ICollectService
    {
        IDatabaseFactory dbfactory = null;
        IUnitOfWork uow = null;
        public CollectService()
        {
            dbfactory = new DatabaseFactory();
            uow = new UnitOfWork(dbfactory);
        }
        public void AddCollect(Collect c)
        {
            uow.CollectRepository.Add(c);
        }

        public void DeleteCollect(Collect c)
        {
            uow.CollectRepository.Delete(c);
        }

        public void Dispose()
        {
            uow.Dispose();
        }

        public IEnumerable<Collect> GetAllEvent()
        {
            return uow.CollectRepository.GetAll();
        }

        public object GetByIdCollect(int id)
        {
            return uow.CollectRepository.GetById(id);
        }

        public void SaveChange()
        {
            uow.Commit();
        }

        public void UpdateCollect(Collect c)
        {
            uow.CollectRepository.Update(c);
            uow.Commit();
        }
    }
}
