using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskList.Domain.Entities;
using Task = TaskList.Domain.Entities.Task;

namespace TaskList.Infrastructure.Data
{
    public class TaskDbContext : IdentityDbContext<User,Role,Guid>
    {
        private readonly IConfiguration _configuration;
        public TaskDbContext(DbContextOptions<TaskDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            Database.Migrate();
        }
        public DbSet<Task> Tasks { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);
        } 


        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Manager", ConcurrencyStamp = "3", NormalizedName = "Manager" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }

                );
        }


    }
}
