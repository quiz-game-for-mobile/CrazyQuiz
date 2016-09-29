using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace CrazyQuiz.Droid
{
    [Activity(Theme = "@style/CrazyQuiz.Base")]
    public class MainActivity : AppCompatActivity
    {
        private Button _startBtn;
        private Button _highScoresBtn;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            _startBtn = FindViewById<Button>(Resource.Id.StartButton);
            _highScoresBtn = FindViewById<Button>(Resource.Id.HighScoresButton);

            _startBtn.Click += StartButton_Click;
            _highScoresBtn.Click += HighScoresBtnOnClick;
        }

        private void HighScoresBtnOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(HighScoresActivity));
            StartActivity(intent);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _startBtn.Text = Resources.GetString(Resource.String.Start);
            StartGameActivity();
        }

        private void StartGameActivity()
        {
            var intent = new Intent(this, typeof(QuestionaryActivity));
            StartActivity(intent);
        }
    }
}

