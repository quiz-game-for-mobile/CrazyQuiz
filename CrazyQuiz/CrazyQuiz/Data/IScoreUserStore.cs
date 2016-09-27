using System;

namespace CrazyQuiz.Data
{
    public interface IScoreUserStore : IDisposable
    {
        void SaveUser(ScoreUser user);
        ScoreUser GetUser(string name);
    }
}