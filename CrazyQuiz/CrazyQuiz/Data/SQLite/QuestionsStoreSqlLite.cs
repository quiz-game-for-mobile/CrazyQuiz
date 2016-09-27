using System.Linq;

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

            //if (!DB.Table<Question>().Any())
                SeedDatabase();
        }

        private void SeedDatabase()
        {
            SaveQuestion(
                "Qual elemento não pertence?", 4,
                "Carro",
                "Caminhão",
                "Cadeira de Rodas",
                "Barco"
            );

            SaveQuestion(
                "Marque a resposta 5!", 3,
                "Ceis",
                "5",
                "120",
                "48"
            );

            SaveQuestion(
                "Quantos lados possui um dado?", 1,
                "2",
                "4",
                "6",
                "8"
            );
        }

        private void SaveQuestion(string text, int rightQuestion, params string[] options)
        {
            var question = new Question(text);
            SaveQuestion(question);
            _optionsStore.SaveOptions(question, rightQuestion, options);
        }

        public void SaveQuestion(Question question)
        {
            DB.Insert(question);
        }

        public Question GetRandom()
        {
            var questions = DB.Query<Question>("select * from questions order by random() limit 1");
            return questions.FirstOrDefault();
        }
    }
}
