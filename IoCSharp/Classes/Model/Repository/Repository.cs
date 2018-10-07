using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoCSharp.Framework.Attributes;

namespace IoCSharp.Classes.Model.Repository
{
    abstract class Repository<E, Id> : IRepository<E,Id>
    {
        public void Insert(E row)
        {
            this.GetInsertSentence(row);
        }

        public E FindOne(Id id)
        {
            throw new NotImplementedException();
        }

        public void Update(Id id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Id id)
        {
            throw new NotImplementedException();
        }

        protected abstract string GetInsertSentence(E row);


    }
}
