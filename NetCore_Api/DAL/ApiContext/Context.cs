using Microsoft.EntityFrameworkCore;
using NetCore_Api.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_Api.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-NODMT1N; database=BlogProjeDB2; integrated security=true");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
