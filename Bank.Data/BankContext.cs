using System.Dynamic;
using System.Linq;
using Bank.Data.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bank.Data
{
    
    /*
     This class is used to query and save data to the database. It also contains the connection string to the db.
     Inherits from the DbContext class
     */
    public class BankContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payee> Payees { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public IConfiguration Configuration { get; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {    // Here we choose our data source
            optionsBuilder.UseSqlServer(
                "Server=sql-banking-app.database.windows.net,1433;Database=sqldb-banking-app;UID=uami-bank-app-db;Authentication=Active Directory Interactive");
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
        }

        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
