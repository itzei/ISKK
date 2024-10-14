using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ReactWithAsp.Server.Models.Entities;

namespace ReactWithAsp.Server.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): IdentityDbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored, CoreEventId.NavigationBaseIncluded));
        } 
    }
}