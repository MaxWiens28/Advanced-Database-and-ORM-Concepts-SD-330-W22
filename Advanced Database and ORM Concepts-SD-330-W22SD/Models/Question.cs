namespace Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Tag>? Tags { get; set; } = new HashSet<Tag>();
        public ICollection<Answer> Answers { get; set; } = new HashSet<Answer>();
        public string UserID { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
