using SQLite;
namespace LastExercise.Models
{
    public class NhanVien
    {
        [PrimaryKey, NotNull]
        public int ID { get; set; }
        [NotNull, MaxLength(100)]
        public string Name { get; set; }
        [NotNull, MaxLength(12)]
        public string Date { get; set; }
        [MaxLength(200)]
        public string Desc { get; set; }
        [MaxLength(200)]
        public string IMG { get; set; }
    }
}
