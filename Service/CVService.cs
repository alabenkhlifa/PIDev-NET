﻿using Data.Infrastructure;
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
    }
}
