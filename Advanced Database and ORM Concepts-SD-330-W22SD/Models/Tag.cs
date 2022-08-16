namespace Advanced_Database_and_ORM_Concepts_SD_330_W22SD.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }
}
