using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL;

public class PhoneBookContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Phone> Phones { get; set; }


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

}

public class bloggingCnotextFactory : IDesignTimeDbContextFactory<PhoneBookContext>
{
    public PhoneBookContext CreateDbContext(string[] args)
    {
       
       //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        var opionBuilder = new DbContextOptionsBuilder<PhoneBookContext>();

        //  var connString = configuration.GetConnectionString("DefaultConnection");
        // opionsBuilder.UseSqlServer(@"");
        opionBuilder.UseSqlServer(@"Server=localhost;Database=PhoneBook;User Id=sa;Password=Docker@123;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=True"
);
        
        return new PhoneBookContext(opionBuilder.Options);
    }

}