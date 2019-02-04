﻿using CrudASP_NET_CORE.Controllers.Model;
using System.Collections.Generic;

namespace CrudASP_NET_CORE.Buseness
{
    public interface IPersonBuseness
    {
        Person Create(Person person);
        Person FindByI(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}