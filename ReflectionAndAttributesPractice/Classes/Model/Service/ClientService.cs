using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionAndAttributesPractice.Attributes;
using ReflectionAndAttributesPractice.Classes.Model.Repository;

namespace ReflectionAndAttributesPractice.Classes.Model.Service
{
    [ManagedBean(name = "clientService")]
    class ClientService : IClientService
    {
        [Inject(injectableName = "clientRepository")]
        private IClientRepository clientRepository;

        void IClientService.print()
        {
            clientRepository.print();
        }
    }
}
