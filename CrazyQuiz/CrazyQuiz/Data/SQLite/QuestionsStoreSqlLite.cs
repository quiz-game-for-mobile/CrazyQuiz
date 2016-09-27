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
            
            SaveQuestion(
                "Como se conserta um pneu de um carro?", 2,
                "Usando uma ferramenta adequada para consertar o defeito",
                "Com as mãos",
                "Com um estepe",
                "Tapando os buracos"
            );
            
            SaveQuestion(
                "Quanto vale 5 + K?", 3,
                "13",
                "5000",
                "18",
                "Nenhuma das respostas acima"
            );
            
            SaveQuestion(
                "Qual é o acompanhante ideal para Cream Cracker?", 2,
                "Café",
                "Barra de cereal",
                "Mateiga",
                "Maçã"
            );
            
            SaveQuestion(
                "Qual é a resposta para o criptograma?", 1,
                "!@#$%¨&@*(*",
                "!@#$%¨&@*(*",
                "!@#$%¨&@*(*",
                "!@#$%¨&@*(*",
            );
            
            SaveQuestion(
                "Q__m _e_co_r__ o __a_i_?", 1,
                "_e__o _l__re_ __b_al",
                "__s_o d_ __m_",
                "_ri_to__o C__o_bo",
                "P_r_ _a_ _e _am__h_"
            );
            
            SaveQuestion(
                "Qual destas palavras não é do português?", 4,
                "Alpaca",
                "Álcool",
                "All-Star",
                "Casa"
            );
            
            SaveQuestion(
                "Quanto é 1 + 3 em hexadecimal?", 1,
                "B",
                "4",
                "D",
                "100"
            );
             
            SaveQuestion(
                "Qual destes é o nome mais adequado para um rei?", 1,
                "Mufasa",
                "Arthur",
                "Pedro",
                "Herodes"
            );
             
            SaveQuestion(
                "Qual é o equipamento mais adequado para escalar uma montanha?", 2,
                "Corda",
                "Régua",
                "Luvas",
                "Picaretas"
            );
             
            SaveQuestion(
                "Qual o número usado pelos astrólogos para indicar uma estrela vermelha?", 2,
                "45",
                "13",
                "22",
                "65"
            );
             
            SaveQuestion(
                "Qual destes objetos é o mais verde?", 1,
                "Carvalho seco",
                "Tala Verde",
                "Ísis Valverde",
                "40"
            );
             
            SaveQuestion(
                "Você acha que vai acertar todas as questões?", 3,
                "Pode apostar!",
                "Tenho esperança!",
                "Talvez?",
                "Nem sonhando!"
            );
          
            SaveQuestion(
                "Qual destes usa óculos?", 3,
                "Câmera",
                "Senhor Idoso",
                "Google",
                "Oftamologista"
            );
            
            SaveQuestion(
                "Quanto é 8246 - 48?", 3,
                "8197",
                "48",
                "26",
                "1"
            );
              
            SaveQuestion(
                "Quanto é 12 + 21?", 2,
                "35",
                "110",
                "2111",
                "6"
            );
              
            SaveQuestion(
                "20. Quantas perguntas foram feitas até agora?", 3,
                "19",
                "20",
                "21",
                "22"
            );
              
            SaveQuestion(
                "Qual é o prêmio que você ganha ao responder esta questão?", 3,
                "Glória eterna",
                "Um milhão de reais",
                "Mais perguntas",
                "Um lugar na tabela de pontuações"
            );
               
            SaveQuestion(
                "Pmpaprpqpupe pap prpepspppopsptpa pdpopipsp!p", 2,
                "1",
                "2",
                "3",
                "4"
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
