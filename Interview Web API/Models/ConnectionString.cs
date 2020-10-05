using Interview_Web_API.Database.Entity;
using Microsoft.EntityFrameworkCore;
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

        public DbSet<Employee> Employee { get; set; }
    }
}
