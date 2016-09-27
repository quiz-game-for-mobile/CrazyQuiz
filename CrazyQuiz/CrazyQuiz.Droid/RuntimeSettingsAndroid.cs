using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;

namespace CrazyQuiz.Droid
{
    internal class RuntimeSettingsAndroid : AppRuntimeSettingsBase
    {
        public override ISQLitePlatform SQLitePlatform { get; } = new SQLitePlatformAndroid();
        public override string DatabasePath => System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
    }
}