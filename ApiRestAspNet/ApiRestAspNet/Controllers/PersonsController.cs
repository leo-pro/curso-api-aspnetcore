using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestAspNet.Services;
using ApiRestAspNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestAspNet.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonService _personService;

        public PersonsController(PersonService personService)
        {
            _personService = personService;
        }

        // GET api/persons
        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            var persons = await _personService.FindAllAsync();
            return persons;
        }

        // GET api/persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonsById(int id)
        {
            var person = await _personService.FindByIdAsync(id);
            return person;
        }

        // POST api/persons
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/persons/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
