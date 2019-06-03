using ApiRestAspNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestAspNet.Data
{
    public class RestApiContext : DbContext
    {
        public RestApiContext (DbContextOptions<RestApiContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}
