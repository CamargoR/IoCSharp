using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using IoCSharp.Framework.Attributes;
using IoCSharp.Classes.Framework.Util;

namespace IoCSharp.Classes.Framework.Context
{
    class ContextManager
    {
        private static Boolean contextCreated;

        public static T GetBean<T>(string name)
        {
            return Context.Instance().GetInstance<T>(name);
        }

        public static void CreateContext() 
        {
            if (!contextCreated)
            {
                RegisterBeans();
                InjectBeans();
                contextCreated = true;
            }
        }


        //---------------------------
        private static void RegisterBeans()
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
                            Type beanType;
                            if (bean.singleton)
                            {
                                beanType = ReflectionUtil.MakeGenericType(typeof(Singleton<>), type);
                            }
                            else
                            {
                                beanType = ReflectionUtil.MakeGenericType(typeof(Prototype<>), type);
                            }
                            object[] args = { bean.name, type };
                            Context.Instance().AddBean(bean.name, Activator.CreateInstance(beanType, args));

                        }
                    }
                }
            }
        }

        private static void InjectBeans()
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

                            field.SetValue(bean.GetType().GetField("instance", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(bean), 
                                injectableBean.GetType().GetField("instance",BindingFlags.NonPublic | BindingFlags.Instance).GetValue(injectableBean));
                        }
                    });

                }
            }
        }

    }
}
