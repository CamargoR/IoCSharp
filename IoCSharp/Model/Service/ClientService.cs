using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCSharp.Framework.Attributes;
using IoCSharp.Model.Repository;

namespace IoCSharp.Model.Service
{
    [ManagedBean(name = "clientService", singleton = false)]
    class ClientService : IClientService
    {
        [Inject(injectableName = "clientRepository")]
        private ClientRepository clientRepository;

        public void print()
        {
            //Console.WriteLine("ClientService");
            clientRepository.print();
        }

    }
}
