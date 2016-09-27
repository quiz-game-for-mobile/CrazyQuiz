using System.Linq;
using CrazyQuiz.Data;

namespace CrazyQuiz
{
    public class QuestionarySession
    {
        private readonly IQuestionsStore _questions;
        private readonly IOptionsStore _options;
        private int _lifes;

        public int Lifes
        {
            get { return _lifes; }
            private set
            {
                _lifes = value;
                if (_lifes <= 0) throw new GameOverException();
            }
        }

        public int Scores { get; private set; }
        public int CurrentQuestionNumber { get; private set; }
        public Question CurrentQuestion { get; private set; }

        public const int ScoresPerQuestion = 10;

        public QuestionarySession(IQuestionsStore questions, IOptionsStore options)
        {
            _questions = questions;
            _options = options;
            CurrentQuestionNumber = 1;
            Lifes = 5;
            Scores = 0;
            NextQuestion();
        }

        private void NextQuestion()
        {
            CurrentQuestion = _questions.GetRandom();
        }

        public bool AnswerQuestion(int itemNumber)
        {
            var options = _options.GetOptions(CurrentQuestion).ToList();
            if (_options.IsRigthOption(CurrentQuestion, options[itemNumber]))
            {
                Scores += ScoresPerQuestion;
                CurrentQuestionNumber++;
                NextQuestion();
                return true;
            }
            
            Lifes--;
            return false;
        }
    }
}
