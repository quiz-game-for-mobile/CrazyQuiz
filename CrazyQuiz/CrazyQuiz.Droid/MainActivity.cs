using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CrazyQuiz.Data.SQLite;

namespace CrazyQuiz.Droid
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private int _count;
        private Button _startBtn;
        private RuntimeSettingsAndroid _runtime;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            _runtime = new RuntimeSettingsAndroid();
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);

            _startBtn = FindViewById<Button>(Resource.Id.MyButton);
            _startBtn.Click += StartButton_Click;
        }


        private void StartButton_Click(object sender, EventArgs e)
        {
            _count++;
            if (_count < 2)
                _startBtn.Text = "Você realmente quer jogar?";
            else
                AskForUserName();
        }

        private void AskForUserName()
        {
            var tr = FragmentManager.BeginTransaction();
            var dialog = new UserDialog(_runtime);
            tr.SetTransition(FragmentTransit.FragmentFade);
            dialog.Show(tr, "user_dialog");
        }
    }
}

