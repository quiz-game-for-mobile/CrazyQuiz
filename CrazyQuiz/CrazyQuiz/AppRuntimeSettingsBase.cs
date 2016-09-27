using SQLite.Net.Interop;

namespace CrazyQuiz
{
    public abstract class AppRuntimeSettingsBase : IAppRuntimeSettings
    {
        public string DatabaseFilename { get; } = "crazyquiz.db";
        public abstract ISQLitePlatform SQLitePlatform { get; }
        public abstract string DatabasePath { get; }
    }
}
