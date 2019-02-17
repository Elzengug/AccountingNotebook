using AccountingNotebook.DAL.Data.Contracts;
using AccountingNotebook.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebook.DAL.Data.Implementations
{
    public class AccountNotebookDbContext : DbContext, IDbContext
    {
        public AccountNotebookDbContext(DbContextOptions<AccountNotebookDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions{ get; set; } 
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AccountNotebookDbContext>
    {
        public AccountNotebookDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AccountNotebookDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new AccountNotebookDbContext(builder.Options);
        }
    }
}
