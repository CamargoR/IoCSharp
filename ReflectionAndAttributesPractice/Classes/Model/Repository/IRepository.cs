﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttributesPractice.Classes.Model.Repository
{
    interface IRepository<E, Id>
    {
        void Insert(E row);

        E FindOne(Id id);

        void Update(Id id);

        void Delete(Id id);
    }
}