using BePresent.Repository.Implementation.Entities;
using Microsoft.EntityFrameworkCore;

namespace BePresent.DbContext
{
    public class BePresentDbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Class> Classees { get; set; }
        public DbSet<Attendence> Attendences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BePresentDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }
}
