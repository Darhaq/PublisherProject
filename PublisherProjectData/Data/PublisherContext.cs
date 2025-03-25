using Microsoft.EntityFrameworkCore;
using PublisherProjectData.Models;
using System.Xml;

namespace PublisherProjectData.Data
{
    public class PublisherContext : DbContext
    {
        private readonly DbContextOptions _dbContextOptions;

        public PublisherContext(DbContextOptions dbContextOptions)
          : base(dbContextOptions)
        {
            this._dbContextOptions = dbContextOptions;
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //  "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ProjectPublisherDB"
            //);

            //    .LogTo(Console.WriteLine,
            //        new[] { DbLoggerCategory.Database.Command.Name },
            //        LogLevel.Information)
            //.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurer Book.BasePrice til at have præcision (7, 2)
            modelBuilder.Entity<Book>()
            .Property(e => e.BasePrice)
            .HasPrecision(7, 2);

            // Konfigurer relationen mellem Author og Book
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books) // En Author har mange Books
                .WithOne(b => b.Author) // En Book tilhører én Author
                .HasForeignKey(b => b.AuthorId); // Foreign key i Book

            // Konfigurer relationen mellem Book og Cover
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Covers) // En Book har mange Covers
                .WithOne(c => c.Book) // Et Cover tilhører én Book
                .HasForeignKey(c => c.BookId); // Foreign key i Cover

            // Konfigurer relationen mellem Cover og Artist (many-to-many)
            modelBuilder.Entity<Cover>()
                .HasMany(c => c.Artists) // Et Cover har mange Artists
                .WithMany(a => a.Covers) // En Artist har mange Covers
                .UsingEntity(j => j.ToTable("CoverArtist")); // Navnet på join-tabellen


        }
    }
}
