using SQLite.Net.Interop;

namespace CrazyQuiz
{
    public interface IAppRuntimeSettings
    {
        ISQLitePlatform SQLitePlatform { get; }
        string DatabasePath { get; }
        string DatabaseFilename { get; }
    }
}
