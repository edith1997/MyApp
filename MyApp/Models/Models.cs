using SQLite;

namespace MyApp.Models
{
    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Game { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
