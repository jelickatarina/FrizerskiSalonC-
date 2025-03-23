using KJFZ.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace KJFZ.Data
{
    public class KJFZContext : DbContext
    {
        public KJFZContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //=> optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KJFS;Trusted_Connection=True;MultipleActiveResultSets=true");
                        => optionsBuilder.UseSqlServer("Server=DESKTOP-06M5UEA\\SQLEXPRESS;Database=KJFS;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");


        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Termin> Termin { get; set; }
        public DbSet<Usluga> Usluga { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");

            modelBuilder.Entity<Termin>().ToTable("Termin");

            modelBuilder.Entity<Usluga>().ToTable("Usluga");
        }

    }
}



