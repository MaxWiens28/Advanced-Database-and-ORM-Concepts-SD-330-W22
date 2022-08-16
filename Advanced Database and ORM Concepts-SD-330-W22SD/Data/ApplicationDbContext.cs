using Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models.Question>? Question { get; set; }
        public DbSet<Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models.Answer>? Answer { get; set; }
        public DbSet<Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models.Tag>? Tag { get; set; }
    }
}