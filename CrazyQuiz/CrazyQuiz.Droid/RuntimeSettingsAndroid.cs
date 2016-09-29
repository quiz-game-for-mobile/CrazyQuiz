using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;

namespace CrazyQuiz.Droid
{
    internal class RuntimeSettingsAndroid : AppRuntimeSettingsBase
    {
        public override ISQLitePlatform SQLitePlatform { get; }
        public override string DatabasePath => System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public RuntimeSettingsAndroid()
        {
            SQLitePlatform = new SQLitePlatformAndroid();
        }
    }
}