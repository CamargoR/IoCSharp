using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCSharp.Framework.Attributes;
using IoCSharp.Framework.Context;
using IoCSharp.Model.Repository;
using IoCSharp.Model.Service;

namespace IoCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ContextManager.CreateContext();
            
            IClientRepository repo1 = ContextManager.GetBean<ClientRepository>("clientRepository");
            IClientRepository repo2 = ContextManager.GetBean<ClientRepository>("clientRepository");

            Console.WriteLine(Object.ReferenceEquals(repo1, repo2));

            IClientService c1 = ContextManager.GetBean<ClientService>("clientService");
            IClientService c2 = ContextManager.GetBean<ClientService>("clientService");

            Console.WriteLine(Object.ReferenceEquals(c1, c2));

            NonBeanRepo nonBeanRepo = ContextManager.InjectedOf<NonBeanRepo>(typeof(NonBeanRepo));
            nonBeanRepo.print();


            Console.ReadKey();
        }
    }
}
