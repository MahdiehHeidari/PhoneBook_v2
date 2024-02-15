
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DataContext
{
    public class PhoneBookContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBulider = new DbContextOptionsBuilder<PhoneBookContext>();
                opsBulider.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBulider.Options;
            }

            public DbContextOptionsBuilder<PhoneBookContext> opsBulider { get; set; }
            public DbContextOptions<PhoneBookContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();

        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>()
                .HasOne(p => p.Person)
                .WithMany(p => p.Phones)
                .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<Phone>()
          .Property(e => e.Type)
          .HasConversion(
              v => (int)v, // Convert enum to int
              v => (PhoneType)v // Convert int to enum
          );

            modelBuilder.Entity<Person>().Navigation(e => e.Phones).AutoInclude();
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }

    }
}
