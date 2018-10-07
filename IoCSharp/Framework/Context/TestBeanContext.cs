using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using IoCSharp.Framework.Attributes;
using IoCSharp.Model.Repository;
using IoCSharp.Model.Service;
using IoCSharp.Framework.Util;


namespace IoCSharp.Framework.Context
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
                                Type singletonType = ReflectionUtil.MakeGenericType(typeof(Singleton<>), type);
                                object[] args = { bean.name, type };

                                Context.Instance().AddBean(bean.name, Activator.CreateInstance(singletonType, args));
                            }
                        }                        
                    }
                }                
            }
        }


        public static void InjectBeans()
        {
            IEnumerable<object> beans = Context.Instance().GetBeans();

            foreach (dynamic bean in beans)
            {
                FieldInfo[] beanTypeFields = bean.Type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

                foreach (FieldInfo field in beanTypeFields)
                {
                    IEnumerable<Attribute> fieldAttributes = field.GetCustomAttributes();
                    fieldAttributes.ToList().ForEach(fieldAttribute => 
                    {
                        if (fieldAttribute is Inject)
                        {
                            Inject inject = (Inject)fieldAttribute;
                            object injectableBean = Context.Instance().GetBean(inject.injectableName);

                            field.SetValue(bean.Instance(), injectableBean.GetType().GetMethod("Instance").Invoke(injectableBean, null));
                        }                    
                    });

                }
            }
        }


    }
}
