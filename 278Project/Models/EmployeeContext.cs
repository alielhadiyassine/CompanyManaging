using Microsoft.EntityFrameworkCore;

namespace _278Project.Models
{
    public class EmployeeContext:DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<MatchingModel> Matchings { get; set; }
        public DbSet<UserModel> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source= C:\Users\aliel\Desktop\Spring 2022\CMPS 278\Project\Source\278Project\database.db");
    }
}
