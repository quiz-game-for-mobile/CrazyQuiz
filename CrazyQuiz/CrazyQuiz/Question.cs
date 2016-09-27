using System.Collections.Generic;
using CrazyQuiz.Data;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace CrazyQuiz
{
    [Table("questions")]
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Text { get; set; }

        [ForeignKey(typeof(QuestionOption))]
        public int RigthOptionId { get; set; }

        public Question() {}
        public Question(string text)
        {
            Text = text;
        }
    }
}
