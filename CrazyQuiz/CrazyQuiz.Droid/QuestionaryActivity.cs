using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CrazyQuiz.Data;
using CrazyQuiz.Data.SQLite;
using CrazyQuiz.Exceptions;

namespace CrazyQuiz.Droid
{
    [Activity]
    public class QuestionaryActivity : Activity
    {
        private TextView _questionNumberTextView;
        private TextView _questionTextView;
        private TextView _lifesTextView;
        private TextView _scoresTextView;
        private ListView _optionsListView;
        private IQuestionsStore _questionsStore;
        private IOptionsStore _optionsStore;
        private IAppRuntimeSettings _settings;
        private QuestionarySession _session;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Questionary);

            _settings = new RuntimeSettingsAndroid();
            _optionsStore = new OptionsStoreSqlLite(_settings);
            _questionsStore = new QuestionsStoreSqlLite(_settings, _optionsStore);
            _session = new QuestionarySession(_questionsStore, _optionsStore);
            _questionNumberTextView = FindViewById<TextView>(Resource.Id.QuestionNumberTextView);
            _questionTextView = FindViewById<TextView>(Resource.Id.QuestionTextView);
            _optionsListView = FindViewById<ListView>(Resource.Id.OptionsListView);
            _lifesTextView = FindViewById<TextView>(Resource.Id.LifesTextView);
            _scoresTextView = FindViewById<TextView>(Resource.Id.ScoresTextView);
            _optionsListView.ChoiceMode = ChoiceMode.Single;
            _optionsListView.ItemClick += OptionsListViewOnItemClick;

            UpdatePontuations();
            PopulateQuestion();
        }

        private void UpdatePontuations()
        {
            _questionNumberTextView.Text = _session.CurrentQuestionNumber.ToString();
            _lifesTextView.Text = _session.Lifes.ToString();
            _scoresTextView.Text = _session.Scores.ToString();
        }

        private void PopulateQuestion()
        {
            var question = _session.CurrentQuestion;
            var options = _optionsStore.GetOptions(question);

            _questionTextView.Text = question.Text;
            _optionsListView.Adapter = new ArrayAdapter(
                this,
                Android.Resource.Layout.SimpleListItemSingleChoice,
                options.Select(o => o.Text).ToList()
            );
        }

        private void OptionsListViewOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            try
            {
                if (_session.AnswerQuestion(itemClickEventArgs.Position))
                { 
                    PopulateQuestion();
                    ShowEarnScoresToast();
                }
                else
                    ShowLostLifeToast();

                UpdatePontuations();
            }
            catch (GameOverException)
            {
                CallGameOver();
            }
            catch (GameCompleteException)
            {
                CallGameComplete();
            }
        }

        private void ShowLostLifeToast()
        {
            Toast
                .MakeText(this, Resources.GetString(Resource.String.LessLife), ToastLength.Short)
                .Show();
        }

        private void ShowEarnScoresToast()
        {
            var earnScores = Resources.GetString(Resource.String.EarnScores);
            Toast
                .MakeText(this, string.Format(earnScores, QuestionarySession.ScoresPerQuestion), ToastLength.Short)
                .Show();
        }

        private void CallGameOver()
        {
            Toast
                .MakeText(this, Resources.GetString(Resource.String.GameOver), ToastLength.Long)
                .Show();
            Finish();
        }

        private void CallGameComplete()
        {
            var completeMessage = Resources.GetString(Resource.String.GameComplete);
            Toast
                .MakeText(this, string.Format(completeMessage, _session.Scores), ToastLength.Long)
                .Show();
            Finish();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            _questionsStore.Dispose();
            _optionsStore.Dispose();
        }
    }
}