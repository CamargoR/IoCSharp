using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttributesPractice.Classes.Framework
{
    class ContextManager
    {

        public static object GetBean(string name) 
        {
            return Activator.CreateInstance(Context.Instance().GetBeanType(name));
        }

        public static T GetBean<T>(string name)
        {
            return (T)Activator.CreateInstance(Context.Instance().GetBeanType(name));
        }

    }
}
