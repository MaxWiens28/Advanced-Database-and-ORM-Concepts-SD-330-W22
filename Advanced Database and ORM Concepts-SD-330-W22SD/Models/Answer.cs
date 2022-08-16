namespace Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
