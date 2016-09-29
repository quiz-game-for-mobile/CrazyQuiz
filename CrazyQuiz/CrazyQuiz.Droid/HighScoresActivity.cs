using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CrazyQuiz.Data;
using CrazyQuiz.Data.SQLite;

namespace CrazyQuiz.Droid
{
    [Activity(Theme = "@style/CrazyQuiz.Base")]
    public class HighScoresActivity : Activity
    {
        private ListView _highscoresListView;
        private IScoreUserStore _highscore;
        private IAppRuntimeSettings _settings;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.HighScores);

            _settings = new RuntimeSettingsAndroid();
            _highscore = new ScoreUserStoreSqlLite(_settings);
            _highscoresListView = FindViewById<ListView>(Resource.Id.HighScoresListView);
            var users = _highscore.GetUsers();
            var names = users.Select(u => u.Name + $"\t ({u.Scores})").ToList();
            _highscoresListView.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, names);
        }
    }
}