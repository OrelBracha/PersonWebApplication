using CardComWebApplication.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;

namespace CardComWebApplication.Data
{
    public class PersonDBContext : DbContext
    {
        public PersonDBContext(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<Person> Person { get; set; }



    }
}
