using System;
using System.Collections.Generic;

namespace CrazyQuiz.Data
{
    public interface IScoreUserStore : IDisposable
    {
        void SaveUser(ScoreUser user);
        IEnumerable<ScoreUser> GetUsers();
    }
}