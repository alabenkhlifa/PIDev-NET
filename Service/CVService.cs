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
    public class CVService : Service<CV>
    {
        private static DatabaseFactory dbf = new DatabaseFactory();
        private static UnitOfWork utwk = new UnitOfWork(dbf);

        public CVService() : base(utwk)
        {

        }

        public List<CV> getUnaccepted()
        {
            var response = from c in utwk.getRepository<Candidate>().GetAll()
                           join app in utwk.getRepository<Appointement>().GetAll()
                           on c.id equals app.candidateid
                           join cv in utwk.getRepository<CV>().GetAll()
                           on c.id equals cv.candidateId
                           where c.id.Equals(app.candidateid)
                           select cv;
            return response.ToList();
        }
    }
}
