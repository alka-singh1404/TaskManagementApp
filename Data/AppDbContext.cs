using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using TaskManagementApp.Models;
namespace TaskManagementApp.Data
{
   
        public class AppDbContext : DbContext 
        {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
            public DbSet<TaskModel> Tasks { get; set; }
          

        }
    
}
