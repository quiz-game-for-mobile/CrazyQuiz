using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using CrazyQuiz.Data.SQLite;
using Button = Android.Widget.Button;
using View = Android.Views.View;

namespace CrazyQuiz.Droid
{
    public class UserDialog : DialogFragment
    {
        private readonly IAppRuntimeSettings _settings;
        private EditText _nameText;
        private Button _continueButton;

        public UserDialog(IAppRuntimeSettings settings)
        {
            _settings = settings;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            Dialog.Window.SetTitle(Context.Resources.GetString(Resource.String.SayName));

            return InitializeView(inflater, container);
        }

        private View InitializeView(LayoutInflater inflater, ViewGroup container)
        {
            var view = inflater.Inflate(Resource.Layout.UserDialog, container, false);
            _nameText = view.FindViewById<EditText>(Resource.Id.UserNameText);
            _continueButton = view.FindViewById<Button>(Resource.Id.ContinueBtn);

            _continueButton.Click += ContinueButtonOnClick;

            return view;
        }

        private void ContinueButtonOnClick(object sender, EventArgs eventArgs)
        {
            _continueButton.Clickable = false;
            using (var store = new ScoreUserStoreSqlLite(_settings))
            {
                var user = new ScoreUser(_nameText.Text);
                if (!Validate(user)) return;

                store.SaveUser(user);
                StartGameActivity();
            }
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

        private void StartGameActivity()
        {
            var intent = new Intent(Context, typeof(QuestionaryActivity));
            StartActivity(intent);
            Dismiss();
        }
    }
}