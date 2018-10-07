using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using ReflectionAndAttributesPractice.Attributes;

namespace ReflectionAndAttributesPractice.Classes.Framework
{
    class TestBeanContext
    {
        public static void RegisterBeans()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach (System.Attribute attribute in System.Attribute.GetCustomAttributes(type))
                    {
                        if (attribute is ManagedBean)
                        {
                            ManagedBean bean = (ManagedBean)attribute;
                            if (bean.singleton)
                            {
                                Type singletonType = typeof(Singleton<>);
                                Type[] typeArgs = { type };
                                Type singletonInstance = singletonType.MakeGenericType(typeArgs);
                                object[] args = { bean.name, type };

                                object finalInstance = Activator.CreateInstance(singletonInstance, args);
                                Console.WriteLine("Bean<T> created " + bean.name);
                            }
                        }                        
                    }
                }                
            }
        }


    }
}
