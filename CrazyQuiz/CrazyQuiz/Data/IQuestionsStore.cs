using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyQuiz.Data
{
    public interface IQuestionsStore : IDisposable
    {
        void SaveQuestion(string text, int rightQuestion, params string[] options);
        Question GetRandom(IEnumerable<Question> answeredQuestions);
    }
}
