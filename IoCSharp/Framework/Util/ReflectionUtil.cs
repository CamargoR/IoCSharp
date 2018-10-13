using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoCSharp.Framework.Util
{
    static class ReflectionUtil
    {
        public static Type MakeGenericType(Type classType, Type argumentType)
        {
            Type[] arguments = { argumentType };
            return classType.MakeGenericType(arguments);
        }
    }
}
