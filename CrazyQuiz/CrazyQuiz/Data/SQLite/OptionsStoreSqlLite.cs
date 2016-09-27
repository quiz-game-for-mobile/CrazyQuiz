using System.Collections.Generic;

namespace CrazyQuiz.Data.SQLite
{
    public class OptionsStoreSqlLite : SQLiteRepository, IOptionsStore
    {
        public OptionsStoreSqlLite(IAppRuntimeSettings settings) : base(settings)
        {
            DB.DropTable<QuestionOption>();
            DB.CreateTable<QuestionOption>();
        }

        public bool IsRigthOption(Question question, QuestionOption option)
        {
            return question.RigthOptionId == option.Id;
        }

        public void SaveOptions(Question question, int rigthOption, params string[] options)
        {
            var count = 1;
            foreach (var text in options)
            {
                var option = new QuestionOption(question, text);
                SaveOption(option);

                if (count == rigthOption)
                    question.RigthOptionId = option.Id;

                count++;
            }

            DB.Update(question);
        }

        private void SaveOption(QuestionOption option)
        {
            DB.Insert(option);
        }

        public IEnumerable<QuestionOption> GetOptions(Question question)
        {
            return DB.Table<QuestionOption>().Where(o => o.QuestionId == question.Id).OrderBy(o => o.Id);
        }
    }
}
