using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionAndAttributesPractice.Attributes;
using ReflectionAndAttributesPractice.Classes.Framework;
using ReflectionAndAttributesPractice.Classes.Model.Repository;

namespace ReflectionAndAttributesPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestApplicationContext.RegisterBeans();
            //TestApplicationContext.PrintAttributes();

            //GenericRepository<Context, long> repo = ContextManager.GetBean<GenericRepository<Context,long>>("genericRepository");
            //IClientRepository repo = (IClientRepository)ContextManager.GetBean("clientRepository");
            //repo.print();

            TestBeanContext.RegisterBeans();
            Console.ReadKey();
        }
    }
}
