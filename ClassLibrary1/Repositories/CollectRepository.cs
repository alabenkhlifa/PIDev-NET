using Data.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CollectRepository : RepositoryBase<Collect>, ICollectRepository
    {
        public CollectRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }





        //public object getById()
        //{
        //    throw new NotImplementedException();
        //}
    }

    public interface ICollectRepository : IRepositoryBase<Collect>
    {
    }
}
