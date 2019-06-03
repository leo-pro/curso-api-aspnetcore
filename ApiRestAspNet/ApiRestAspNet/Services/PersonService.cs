using ApiRestAspNet.Data;
using ApiRestAspNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestAspNet.Services
{
    public class PersonService
    {
        private readonly RestApiContext _restApiContext;

        public PersonService(RestApiContext restApiContext)
        {
            _restApiContext = restApiContext;
        }

        // Get All Persons
        public async Task<List<Person>> FindAllAsync()
        {
            return await _restApiContext.Person.ToListAsync();
        }

        // Find Person By your Id
        public async Task<Person> FindByIdAsync(long? id)
        {
            return await _restApiContext.Person.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        // Add new Person
        public async Task InsertAsync (Person person)
        {
            _restApiContext.Add(person);
            await _restApiContext.SaveChangesAsync();
        }

        // Remove person
        public async Task DeleteAsync(long id)
        {
            try
            {
                var obj = await _restApiContext.Person.FindAsync(id);
                _restApiContext.Person.Remove(obj);
                await _restApiContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        
        //Update person's data
        public async Task<Person> UpdateAsync(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = await _restApiContext.Person.SingleOrDefaultAsync(p => p.Id.Equals(person.Id));
            try
            {
                _restApiContext.Entry(result).CurrentValues.SetValues(person);
                await _restApiContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
            return person;
        }

        // verifying if person exists in DB
        private bool Exist(long id)
        {
            return _restApiContext.Person.Any(p => p.Id.Equals(id));
        }
    }
}
