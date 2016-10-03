using System.Collections.Generic;
using System.Linq;
using CrazyQuiz.Data;
using CrazyQuiz.Exceptions;

namespace CrazyQuiz
{
    public class QuestionarySession
    {
        private readonly IQuestionsStore _questions;
        private readonly IOptionsStore _options;
        private int _lifes;
        private readonly List<Question> _answeredQuestions;
        private int _scores;

        public int Lifes
        {
            get { return _lifes; }
            private set
            {
                _lifes = value;
                if (_lifes <= 0) throw new GameOverException();
            }
        }

        public int Scores
        {
            get { return _scores; }
            private set { _scores = value < 0 ? 0 : value; }
        }

        public int CurrentQuestionNumber { get; private set; }
        public Question CurrentQuestion { get; private set; }

        public const int ScoresPerQuestion = 10;
        public const int ScoresPerLife = 3;
        public bool IsGameOver => Lifes <= 0;

        public QuestionarySession(IQuestionsStore questions, IOptionsStore options)
        {
            _questions = questions;
            _options = options;
            _answeredQuestions = new List<Question>();
            CurrentQuestionNumber = 1;
            Lifes = 5;
            Scores = 0;
            NextQuestion();
        }

        private void NextQuestion()
        {
            CurrentQuestion = _questions.GetRandom(_answeredQuestions);

            if (CurrentQuestion == null)
                throw new GameCompleteException();
        }

        public bool AnswerQuestion(int itemNumber)
        {
            var options = _options.GetOptions(CurrentQuestion).ToList();
            if (_options.IsRigthOption(CurrentQuestion, options[itemNumber]))
            {
                _answeredQuestions.Add(CurrentQuestion);
                Scores += ScoresPerQuestion;
                CurrentQuestionNumber++;
                NextQuestion();
                return true;
            }
            
            Lifes--;
            Scores -= ScoresPerLife;
            return false;
        }
    }
}
