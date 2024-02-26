using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Data.Entities;

namespace Tasks.Data.Concrete
{
    public class MyTaskContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-7RCB05G;Initial Catalog=TestDb;Integrated Security=True;Trust Server Certificate=True");
        }
        public DbSet<MyTask> MyTasks { get; set; }

    }
}
