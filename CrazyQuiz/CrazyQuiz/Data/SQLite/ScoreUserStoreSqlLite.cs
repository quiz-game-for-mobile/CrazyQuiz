using System.Linq;

namespace CrazyQuiz.Data.SQLite
{
    public class ScoreUserStoreSqlLite : SQLiteRepository, IScoreUserStore
    {
        public ScoreUserStoreSqlLite(IAppRuntimeSettings settings) : base(settings)
        {
            DB.CreateTable<ScoreUser>();
        }

        public void SaveUser(ScoreUser user)
        {
            if (GetUser(user.Name) == null)
                DB.Insert(user);
        }

        public ScoreUser GetUser(string name)
        {
            return DB.Table<ScoreUser>().FirstOrDefault(u => u.Name == name);
        }
    }
}