using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionAndAttributesPractice.Classes.Framework.Exception;

namespace ReflectionAndAttributesPractice.Classes.Framework
{
    class Context
    {
        private IDictionary<string, Type> beans;

        private static Context context;

        private Context()
        {
            this.beans = new Dictionary<string, Type>();
        }

        public static Context Instance() 
        {
            if (context == null)
            {
                context = new Context();
            }

            return context;
        }

        public Type GetBeanType(string beanName)
        {
            if (!this.beans.ContainsKey(beanName))
            {
                throw new BeanDefinitionException("There is not any bean named [" + beanName +"].");
            }

            return this.beans[beanName];
        }

        public void AddBean(string name, Type type)
        {
            if (this.beans.ContainsKey(name))
            {
                throw new BeanDefinitionException("A bean named [" + name + "] already exists in context.");
            }
            
            this.beans.Add(name, type);
        }

        public IEnumerable<string> GetAllNames()
        {
            return this.beans.Keys.ToList();
        }

        public IEnumerable<Type> GetAllTypes()
        {
            return this.beans.Values.ToList();
        }

    }
}
