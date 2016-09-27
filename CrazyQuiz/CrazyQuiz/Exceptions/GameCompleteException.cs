using System;

namespace CrazyQuiz.Exceptions
{
    public class GameCompleteException : Exception
    {
        public GameCompleteException()
        {
        }

        public GameCompleteException(string message) : base(message)
        {
        }

        public GameCompleteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}