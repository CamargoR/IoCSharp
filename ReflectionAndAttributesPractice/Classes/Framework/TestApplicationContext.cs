using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionAndAttributesPractice.Classes.Model.Repository;
using ReflectionAndAttributesPractice.Attributes;
using System.Reflection;

namespace ReflectionAndAttributesPractice.Classes.Framework
{
    class TestApplicationContext
    {
        public static void RegisterBeans()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    System.Attribute[] attributes = System.Attribute.GetCustomAttributes(type);

                    foreach (System.Attribute attribute in attributes)
                    {
                        //if (attribute is ManagedRepository)
                        //{
                        //    ManagedRepository repo = (ManagedRepository)attribute;
                        //    Context.Instance().AddBean(repo.name, type);
                        //}

                        //if (attribute is ManagedService)
                        //{
                        //    ManagedService service = (ManagedService)attribute;
                        //    Context.Instance().AddBean(service.name, type);
                        //}
                        
                        if (attribute is ManagedBean)
                        {
                            ManagedBean injectable = (ManagedBean)attribute;
                            Context.Instance().AddBean(injectable.name, type);
                        }
                    }
                }
            }
        }


        public static void PrintAttributes() 
        {
            foreach (string beanName in Context.Instance().GetAllNames())
            {
                Type beanType = Context.Instance().GetBeanType(beanName);
                System.Attribute[] atts = System.Attribute.GetCustomAttributes(beanType);

                foreach (System.Attribute at in atts)
                {
                    if (at is ManagedService)
                    {
                        object bean = Activator.CreateInstance(beanType);
                        FieldInfo[] fields = beanType.GetFields();

                        foreach (FieldInfo field in fields)
                        {
                            IEnumerable<Inject> fieldAttributes = field.GetCustomAttributes(typeof(Inject), false).Cast<Inject>().ToList();
                            object injectable = Activator.CreateInstance(field.GetType());
                            field.SetValue(bean,injectable);

                            fieldAttributes.ToList().ForEach(fieldAttribute => Console.WriteLine(fieldAttribute.injectableName));
                        }
                    }
                }

            }        
        }
    }
}
