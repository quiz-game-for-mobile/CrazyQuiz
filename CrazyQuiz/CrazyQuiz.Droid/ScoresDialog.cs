using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using CrazyQuiz.Data;
using CrazyQuiz.Data.SQLite;
using Button = Android.Widget.Button;
using View = Android.Views.View;

namespace CrazyQuiz.Droid
{
    public class ScoresDialog : DialogFragment
    {
        private readonly IScoreUserStore _scores;
        private EditText _nameText;
        private Button _continueButton;
        private TextView _finalScoresTextView;
        private readonly QuestionarySession _session;

        public ScoresDialog(QuestionarySession session)
        {
            _session = session;
            _scores = new ScoreUserStoreSqlLite(new RuntimeSettingsAndroid());
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var message = _session.IsGameOver ? Resource.String.GameOver : Resource.String.GameComplete;
            Dialog.Window.SetTitle(Context.Resources.GetString(message));

            return InitializeView(inflater, container);
        }

        private View InitializeView(LayoutInflater inflater, ViewGroup container)
        {
            var view = inflater.Inflate(Resource.Layout.ScoresDialog, container, false);
            _nameText = view.FindViewById<EditText>(Resource.Id.UserNameText);
            _continueButton = view.FindViewById<Button>(Resource.Id.ContinueBtn);
            _finalScoresTextView = view.FindViewById<TextView>(Resource.Id.FinalScoresTextView);

            _nameText.RequestFocus();

            _continueButton.Click += ContinueButtonOnClick;
            _finalScoresTextView.Text = _session.Scores.ToString("D5");

            return view;
        }

        private void ContinueButtonOnClick(object sender, EventArgs eventArgs)
        {
            var user = new ScoreUser(_nameText.Text, _session.Scores);
            if (!Validate(user)) return;

            _scores.SaveUser(user);

            Dismiss();
        }

        private bool Validate(ScoreUser user)
        {
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                Toast.MakeText(Context, Context.Resources.GetString(Resource.String.RequiredName), ToastLength.Short).Show();
                return false;
            }

            return true;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            var intent = new Intent(Context, typeof(HighScoresActivity));
            StartActivity(intent);

            _scores.Dispose();
        }
    }
}