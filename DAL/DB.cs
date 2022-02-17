using BE;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class DB:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=MatabWebDB;Integrated Security=true;User ID=sa;Password=12345");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Moshavere> moshaveres{ get; set; }
        public DbSet<Nobat> nobats { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<User> users { get; set; }
    }
}
