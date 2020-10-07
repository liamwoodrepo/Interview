using Interview_Web_API.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview_Web_API.Models
{
    public class ConnectionString:DbContext
    {
        public ConnectionString(DbContextOptions<ConnectionString> options):base(options)
        {

        }

        public ConnectionString()
        {
        }

        private const string connectionString = "Data Source=(localdb)\\Interview;Initial Catalog=Interview;Integrated Security=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Employee> Employee { get; set; }
    }
}
