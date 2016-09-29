using System.Collections.Generic;
using System.Linq;
using CrazyQuiz.Data.Seeders;

namespace CrazyQuiz.Data.SQLite
{
    public class QuestionsStoreSqlLite : SQLiteRepository, IQuestionsStore
    {
        private readonly IOptionsStore _optionsStore;

        public QuestionsStoreSqlLite(IAppRuntimeSettings settings, IOptionsStore optionsStore) : base(settings)
        {
            _optionsStore = optionsStore;
            DB.DropTable<Question>();
            DB.CreateTable<Question>();

            if (!DB.Table<Question>().Any())
            {
                var seeder = new QuestionsSeeder(this);
                seeder.Seed();
            }
        }

        public void SaveQuestion(string text, int rightQuestion, params string[] options)
        {
            var question = new Question(text);
            SaveQuestion(question);
            _optionsStore.SaveOptions(question, rightQuestion, options);
        }

        private void SaveQuestion(Question question)
        {
            DB.Insert(question);
        }

        public Question GetRandom(IEnumerable<Question> answeredQuestions)
        {
            var ids = answeredQuestions.Select(q => q.Id);
            var group = string.Join(", ", ids);
            var questions = DB.Query<Question>($"SELECT * FROM questions WHERE id NOT IN ({group}) ORDER BY random() LIMIT 1");
            return questions.FirstOrDefault();
        }
    }
}
