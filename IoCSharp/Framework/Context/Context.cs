using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCSharp.Framework.Exception;

namespace IoCSharp.Framework.Context
{
    class Context
    {
        private IDictionary<string, object> beans;

        private static Context context;

        private Context()
        {
            this.beans = new Dictionary<string, object>();
        }

        public static Context Instance() 
        {
            if (context == null)
            {
                context = new Context();
            }

            return context;
        }

        public void AddBean(string name, object bean)
        {
            ThrowExceptionIfBeanIsAlreadyCreated(name);
            beans.Add(name, bean);
        }

        public object GetBean(string name)
        {
            ThrowExceptionIfBeanDoesNotExist(name);
            return beans[name];
        }

        public IEnumerable<object> GetBeans()
        {
            return this.beans.Values.ToList();
        }

        public T GetInstanceFromBean<T>(string name) 
        {
            ThrowExceptionIfBeanDoesNotExist(name);
            return ((Bean<T>)GetBean(name)).Instance();
        }

        #region Exception handling
        private void ThrowExceptionIfBeanIsAlreadyCreated(string name)
        {
            if (this.beans.ContainsKey(name))
            {
                throw new BeanDefinitionException("A bean named [" + name + "] already exists in context.");
            }
        }

        private void ThrowExceptionIfBeanDoesNotExist(string name)
        {
            if (!this.beans.ContainsKey(name))
            {
                throw new BeanDefinitionException("There is not any bean named [" + name + "].");
            }
        }
        #endregion
    }
}
