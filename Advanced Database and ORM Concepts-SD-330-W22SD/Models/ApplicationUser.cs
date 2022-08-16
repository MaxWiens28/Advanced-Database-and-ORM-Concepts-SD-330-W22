using Microsoft.AspNetCore.Identity;

namespace Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();  
        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public int Reputation { get; set; } = 0;
        public ApplicationUser() : base()
        {

        }
    }
}
