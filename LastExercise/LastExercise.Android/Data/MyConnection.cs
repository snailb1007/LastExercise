using LastExercise.Data;
using LastExercise.Droid.Data;
using SQLite;
using System.IO;
[assembly: Xamarin.Forms.Dependency(typeof(MyConnection))]
namespace LastExercise.Droid.Data
{
    class MyConnection : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = "QLNhaHang_DB.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), documentsPath);
            var conn = new SQLiteAsyncConnection(path);
            return conn;
        }
    }
}