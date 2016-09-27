using System;
using System.IO;
using SQLite.Net;

namespace CrazyQuiz.Data.SQLite
{
    public class SQLiteRepository : IDisposable
    {
        protected SQLiteConnection DB { get; }

        public SQLiteRepository(IAppRuntimeSettings settings)
        {
            DB = new SQLiteConnection(settings.SQLitePlatform, Path.Combine(settings.DatabasePath, settings.DatabaseFilename));
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
