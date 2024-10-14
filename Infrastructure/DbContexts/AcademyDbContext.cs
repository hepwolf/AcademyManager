using AcademyManager.Domain.Entities;
using AcademyManager.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AcademyManager.Infrastructure.DbContexts
{
    public class AcademyDbContext : DbContext
    {
        public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AcademyEntityConfiguration());  
            modelBuilder.ApplyConfiguration(new CourseEntityConfiguration());   
            modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());  
            modelBuilder.ApplyConfiguration(new StudentCourseEntityConfiguration());    
            modelBuilder.ApplyConfiguration(new UserAccuntEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserTokenEntityConfiguration());  
            modelBuilder.ApplyConfiguration(new UserRoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());

            base.OnModelCreating(modelBuilder); 
        }

        //
        // DbSets
        //
        public DbSet<Academy> Academies { get; set;}
        public DbSet<Course> Courses { get; set;}
        public DbSet<Student> Students { get; set;}
        public DbSet<StudentCourse> StudentCourses { get; set;}
        public DbSet<UserAccount> UserAccunts { get; set;}
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}
