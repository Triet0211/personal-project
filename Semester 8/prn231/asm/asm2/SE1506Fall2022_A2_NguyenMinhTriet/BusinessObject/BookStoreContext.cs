using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BookStoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }

        public BookStoreContext() {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionString;
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, true, true);
            var root = configurationBuilder.Build();
            connectionString = root.GetSection("ConnectionStrings").GetSection("BookStoreDB").Value;

            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=BookStoreDB;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                   .HasIndex(u => u.EmailAddress)
                   .IsUnique();

            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleId = 1,
                RoleDescription = "Employee",
            });

            modelBuilder.Entity<Publisher>().HasData(new Publisher()
            {
                PubId = 1,
                PublisherName = "NXB Kim Đồng",
                City = "Hà Nội",
                Country = "Việt Nam",
                State = "",
            });

            modelBuilder.Entity<BookAuthor>()
                    .HasKey(c => new { c.AuthorId, c.BookId });
            modelBuilder.Entity<Book>()
                .HasMany(left => left.Authors)
                .WithMany(right => right.Books)
                //.UsingEntity(join => join.ToTable("BookAuthor"))
                .UsingEntity<BookAuthor>(
                j => j
                    .HasOne(pt => pt.Author)
                    .WithMany(t => t.BooksOfThis)
                    .HasForeignKey(pt => pt.AuthorId),
                j => j
                    .HasOne(pt => pt.Book)
                    .WithMany(p => p.AuthorsOfThis)
                    .HasForeignKey(pt => pt.BookId),
                j =>
                {
                    j.Property(pt => pt.AuthorOrder);
                    j.Property(pt => pt.RoyalityPercentage);
                    j.HasKey(t => new { t.AuthorId, t.BookId });
                });

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Replace table names
                //entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();
                //entity.SetTableName(entity.GetTableName().ToSnakeCase());

                // Replace column names            
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.Name.ToSnakeCase());
                }

                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToSnakeCase());
                }

                foreach (var key in entity.GetForeignKeys())
                {
                    key.PrincipalKey.SetName(key.PrincipalKey.GetName().ToSnakeCase());
                }

                foreach (var index in entity.GetIndexes())
                {
                    index.SetName(index.GetName().ToSnakeCase());
                }
            }
        }
        
    }
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}
