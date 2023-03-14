using Microsoft.EntityFrameworkCore;
using SignalRAssignment_SE151127.Utils;

namespace SignalRAssignment_SE151127.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        
        }

        public ApplicationDBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = AppConfiguration.GetAppsetting("ConnectionStrings", "PostManagementDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                   .HasIndex(u => u.Email)
                   .IsUnique();
        }
    }
}
