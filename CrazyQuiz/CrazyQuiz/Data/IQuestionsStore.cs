using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyQuiz.Data
{
    public interface IQuestionsStore : IDisposable
    {
        void SaveQuestion(Question question);
        Question GetRandom();
    }
}
