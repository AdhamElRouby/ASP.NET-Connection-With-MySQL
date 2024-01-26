using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using MySql.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Model
{
    public class AddDbContext : DbContext
    {
        string connectionString = "server=localhost;database=exp_db;uid=root;pwd=AmR$468181";

        // create a table called Participants
        public DbSet<Participant> Participants { get; set; }
        // create a table called Startups
        public DbSet<Startup> Startups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // connecting to mysql server
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // making the email of a participant and startup names to be unique
            modelBuilder.Entity<Participant>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<Startup>().HasIndex(s => s.StartupName).IsUnique();
        }
    }
    public class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices
    {
        public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddEntityFrameworkMySQL();
            new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
                .TryAddCoreServices();
        }
    }
}
