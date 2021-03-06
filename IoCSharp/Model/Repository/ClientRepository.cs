﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCSharp.Framework.Attributes;

namespace IoCSharp.Model.Repository
{
    [ManagedBean(name = "clientRepository")]
    class ClientRepository : Repository<long,long>, IClientRepository
    {

        protected override string GetInsertSentence(long row)
        {
            return "INSERT INTO TABLE CLIENT";
        }

        public void print()
        {
            Console.WriteLine("IClientRepository successfully retrieved.");
        }
    }
}
