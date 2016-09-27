using System;
using System.Collections.Generic;

namespace CrazyQuiz.Data
{
    public interface IOptionsStore : IDisposable
    {
        bool IsRigthOption(Question question, QuestionOption option);
        void SaveOptions(Question question, int rigthOption, params string[] options);
        IEnumerable<QuestionOption> GetOptions(Question question);
    }
}
