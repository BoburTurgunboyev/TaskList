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
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }


    }
}
