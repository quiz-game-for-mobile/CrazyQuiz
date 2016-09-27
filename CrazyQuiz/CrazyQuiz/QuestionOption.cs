using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace CrazyQuiz
{
    public class QuestionOption
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Text { get; set; }

        [Indexed, ForeignKey(typeof(Question))]
        public int QuestionId { get; set; }

        public QuestionOption() { }
        public QuestionOption(Question question, string text)
        {
            QuestionId = question.Id;
            Text = text;
        }
    }
}
