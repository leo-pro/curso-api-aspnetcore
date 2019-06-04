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
            return await _restApiContext.person.ToListAsync();
        }

        // Find Person By your Id
        public async Task<Person> FindByIdAsync(long? _id)
        {
            return await _restApiContext.person.SingleOrDefaultAsync(p => p.id.Equals(_id));
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
                var obj = await _restApiContext.person.FindAsync(id);
                _restApiContext.person.Remove(obj);
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
            if (!Exist(person.id)) return new Person();

            var result = await _restApiContext.person.SingleOrDefaultAsync(p => p.id.Equals(person.id));
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
        private bool Exist(long _id)
        {
            return _restApiContext.person.Any(p => p.id.Equals(_id));
        }
    }
}
