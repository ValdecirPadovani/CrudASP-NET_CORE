﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CrudASP_NET_CORE.Controllers.Model;
using CrudASP_NET_CORE.Controllers.Model.Context;

namespace CrudASP_NET_CORE.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {

        private MySQLContext _context;

        public PersonServiceImpl(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null) _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindByI(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return person;
        }

        private bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
