using System.Collections.Generic;
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
            if (!Exists(user.Name))
                DB.Insert(user);
            else
                DB.Update(user);
        }

        private bool Exists(string name)
        {
            return DB.Table<ScoreUser>().Any(u => u.Name == name);
        }

        public IEnumerable<ScoreUser> GetUsers()
        {
            return DB.Table<ScoreUser>().OrderByDescending(u => u.Scores);
        }
    }
}