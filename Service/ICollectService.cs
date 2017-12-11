using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
 
    public interface ICollectService : IDisposable
    {
        void AddCollect(Domain.Collect c);
        void UpdateCollect(Domain.Collect c);
        void DeleteCollect(Domain.Collect c);
        System.Collections.Generic.IEnumerable<Domain.Collect> GetAllEvent();
        void SaveChange();
        object GetByIdCollect(int id);
    }
}
