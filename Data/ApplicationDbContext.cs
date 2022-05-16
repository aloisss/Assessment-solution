using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recruitment.Models;

namespace Recruitment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Recruitment.Models.Answers> Answers { get; set; }
        public DbSet<Recruitment.Models.application> application { get; set; }
        public DbSet<Recruitment.Models.application_test> application_test { get; set; }
        public DbSet<Recruitment.Models.interview> interview { get; set; }
        public DbSet<Recruitment.Models.interviewNotes> interviewNotes { get; set; }
        public DbSet<Recruitment.Models.test> test { get; set; }
    }
}