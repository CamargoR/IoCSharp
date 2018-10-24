using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCSharp.Framework.Attributes;

namespace IoCSharp.Model.Repository
{
    class NonBeanRepo
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
