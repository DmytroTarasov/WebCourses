using System.IO;
using EntityDTO.Activities;
using EntityDTO.Course_Structure;
using EntityDTO.Statistic;
using EntityDTO.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class CoursesContext: DbContext
    {
        public CoursesContext(DbContextOptions<CoursesContext> options) : base(options) {}
        public DbSet<QuizDto> Quizzes { get; set; }
        public DbSet<QuizOptionDto> QuizOptions { get; set; }
        public DbSet<TestDto> Tests { get; set; }
        public DbSet<CourseQuizDto> CourseQuizzes { get; set; }
        public DbSet<TopicQuizDto> TopicQuizzes { get; set; }
        public DbSet<UnitQuizDto> UnitQuizzes { get; set; }
        public DbSet<ActivityStatisticDto> ActivityStatistics  { get; set; }

        public DbSet<ActivityDto> Activities { get; set; }
        public DbSet<ActivityTypeDto> ActivityTypes { get; set; }
        public DbSet<CourseDto> Courses { get; set; }
        public DbSet<CourseCategoryDto> CourseCategories { get; set; }
        public DbSet<LectureDto> Lectures { get; set; }
        public DbSet<LectureConstructDto> LectureConstructs { get; set; }
        public DbSet<ConstructTypeDto> ConstructTypes { get; set; }
        public DbSet<TopicDto> Topics { get; set; }
        public DbSet<UnitDto> Units { get; set; }

                
        public DbSet<BadgeStatisticDto> BadgeStatistics  { get; set; }
        public DbSet<CalendarStatisticDto> CalendarStatistics  { get; set; }
        public DbSet<LectureStatisticDto> LectureStatistics  { get; set; }
        public DbSet<QuizOptionStatisticDto> QuizOptionStatistics { get; set; }
        public DbSet<ActivityQuizStatisticDto> ActivityQuizStatistics { get; set; }
        public DbSet<TestStatisticDto> TestStatistics { get; set; }
        public DbSet<CourseQuizStatisticDto> CourseQuizStatistics { get; set; }
        public DbSet<UnitQuizStatisticDto> UnitQuizStatistics { get; set; }
        public DbSet<TopicQuizStatisticDto> TopicQuizStatistics { get; set; }


        public DbSet<BadgeDto> Badges { get; set; }
        public DbSet<NotificationDto> Notifications { get; set; }
        public DbSet<StudentDto> Users { get; set; }
        public DbSet<ProfessorDto> Professors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TopicStatisticDto>()
                .HasOne(st => st.Topic)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TopicStatisticDto>()
                .HasOne(st => st.Student)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ActivityStatisticDto>()
                .HasOne(st => st.Activity)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<ActivityStatisticDto>()
                .HasOne(st => st.Student)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CourseStatisticDto>()
                .HasOne(st => st.Course)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CourseStatisticDto>()
                .HasOne(st => st.Student)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<LectureStatisticDto>()
                .HasOne(st => st.Lecture)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<LectureStatisticDto>()
                .HasOne(st => st.Student)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<UnitStatisticDto>()
                .HasOne(st => st.Unit)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<UnitStatisticDto>()
                .HasOne(st => st.Student)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
   
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoursesContext> 
    { 
        public CoursesContext CreateDbContext(string[] args) 
        { 
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../WebCourses/appsettings.json").Build(); 
            var builder = new DbContextOptionsBuilder<CoursesContext>(); 
            var connectionString = configuration.GetConnectionString("CoursesDB"); 
            builder.UseSqlServer(connectionString); 
            return new CoursesContext(builder.Options); 
        } 
    }
    
}