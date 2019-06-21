using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyContext") { }

        public DbSet<Handover> Handovers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Loaning> Loanings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Procurement> Procurements { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<TypeItem> TypeItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Condition> Conditions { get; set; }
    }
}
