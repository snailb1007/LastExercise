using SQLite;

namespace LastExercise.Data
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
