namespace CrazyQuiz.Data.Seeders
{
    public class QuestionsSeeder : IDataSeeder
    {
        private readonly IQuestionsStore _store;

        public QuestionsSeeder(IQuestionsStore store)
        {
            _store = store;
        }

        public void Seed()
        {
            _store.SaveQuestion(
                "Zeca tinha um canário, Mateus tinha um porco e Nicole tinha um gato. De quem é o passáro?", 1,
                "12K",
                "Nicole",
                "53",
                "Nenhuma das respostas acima"
            );
            
            _store.SaveQuestion(
                "Qual elemento não pertence?", 4,
                "Carro",
                "Caminhão",
                "Cadeira de Rodas",
                "Barco"
            );
            
            _store.SaveQuestion(
                "Qual destes insetos é cowboy?", 3,
                "Formiga",
                "Escorpião",
                "Aranha",
                "Carrapato"
            );
            
            _store.SaveQuestion(
                "Qual a seção do jornal que os cavaleiros da idade média costumavam ler?", 1,
                "Cruzadas",
                "Boletim Policial",
                "Esportes",
                "Tirinhas"
            );
            
            _store.SaveQuestion(
                "Coloque em ordem: 1,5,6,9,4,8,7,2,3,0", 2,
                "6,8,2,7,9,0,1,4,3,5",
                "5,2,8,9,4,6,7,3,1,0",
                "4,0,2,8,9,3,1,7,5,6",
                "0,1,2,3,4,5,6,7,8,9"
            );
            
            _store.SaveQuestion(
                "Qual revista possui olhos?", 4,
                "Quem",
                "Quatro Rodas",
                "Exame",
                "Veja"
            );
            
            _store.SaveQuestion(
                "Qual o conjunto utilizado para cuidar dos gatos?", 2,
                "Iscas Sachê",
                "Kit Kat",
                "Ração Pedigree",
                "Conjunto de Veterinário"
            );
            
            _store.SaveQuestion(
                "Qual é o pais pioneiro no ramo de calçados?", 1,
                "Itália",
                "Sérvia",
                "Alemanha",
                "Espanha"
            );
            
            _store.SaveQuestion(
                "Você ganhou o Crazy Quiz!", 3,
                "Salvar Pontuação",
                "High Scores",
                "Mais Perguntas",
                "Sair"
            );
            
            _store.SaveQuestion(
                "Qual estado brasileiro é masoquista?", 2,
                "São Paulo",
                "Salvador",
                "Acre",
                "Mato Grosso"
            );
            
            _store.SaveQuestion(
                "Qual empresa está sempre a frente da IBM?", 2,
                "Intel Corporation",
                "HAL Laboratory",
                "AMD",
                "Samsung"
            );
            
            _store.SaveQuestion(
                "Qual é o número do silêncio?", 4,
                "5",
                "7",
                "9",
                "X"
            );

            _store.SaveQuestion(
                "Código: 3-15-7-21-13-5-15", 3,
                "Cachorro",
                "Maracujá",
                "Cogumelo",
                "Boxeador"
            );
            
            _store.SaveQuestion(
                "Qual é a profissão de Passos Dias Aguiar?", 1,
                "Táxista",
                "Taxonomista",
                "Padeiro",
                "Sapateiro"
            );
            
            _store.SaveQuestion(
                "Por que as minas terrestres são perigosas?", 2,
                "Porque elas explodem",
                "Porque não existem as alienígenas",
                "Porque ninguém escapa delas",
                "Porque sim"
            );
            
            _store.SaveQuestion(
                "Complete a frase: Querer não __ ______der?", 3,
                "é saber",
                "é poder",
                "apple",
                "google"
            );

            _store.SaveQuestion(
                "Marque a resposta 5!", 3,
                "Ceis",
                "5",
                "120",
                "48"
            );

            _store.SaveQuestion(
                "Quantos lados possui um dado?", 1,
                "2",
                "4",
                "6",
                "8"
            );

            _store.SaveQuestion(
                "Como se conserta um pneu de um carro?", 2,
                "Usando uma ferramenta adequada",
                "Com as mãos",
                "Com um estepe",
                "Tapando os buracos"
            );

            _store.SaveQuestion(
                "Quanto vale 5 + K?", 3,
                "13",
                "5000",
                "18",
                "Nenhuma das respostas acima"
            );

            _store.SaveQuestion(
                "Q__m _e_co_r__ o __a_i_?", 1,
                "_e__o _l__re_ __b_al",
                "__s_o d_ __m_",
                "_ri_to__o C__o_bo",
                "P_r_ _a_ _e _am__h_"
            );

            _store.SaveQuestion(
                "Qual é o plural de \"ar-condicionado\"?", 3,
                "ar-condicionados",
                "ares-condicionado",
                "ares-condicionados",
                "Nenhuma das opções acima"
            );

            _store.SaveQuestion(
                "Toc toc?", 3,
                "Quem bate?",
                "Quem fala?",
                "Quem é?",
                "Quem sois?"
            );

            _store.SaveQuestion(
                "Qual é a comida que liga e desliga?", 3,
                "O tomate",
                "Uma lâmpada",
                "O strogonoff",
                "Leite enriquecido de ferro"
            );

            _store.SaveQuestion(
                "Quanto é 1 + 3?", 1,
                "B",
                "4",
                "D",
                "100"
            );

            _store.SaveQuestion(
                "Qual destes é o nome mais adequado para um rei?", 1,
                "Mufasa",
                "Arthur",
                "Pedro",
                "Herodes"
            );

            _store.SaveQuestion(
                "Qual é o equipamento mais adequado para escalar uma montanha?", 2,
                "Corda",
                "Régua",
                "Luvas",
                "Picaretas"
            );

            _store.SaveQuestion(
                "Qual o número usado pelos astrólogos para indicar uma estrela vermelha?", 2,
                "45",
                "13",
                "22",
                "65"
            );

            _store.SaveQuestion(
                "Qual destes objetos é o mais verde?", 1,
                "1 Real",
                "Uma tartaruga",
                "Ísis Valverde",
                "Partido Verde"
            );

            _store.SaveQuestion(
                "Você acha que vai acertar todas as questões?", 3,
                "Pode apostar!",
                "Tenho esperança!",
                "Talvez um dia?",
                "Nem sonhando!"
            );

            _store.SaveQuestion(
                "Quanto é 8246 - 48?", 3,
                "8197",
                "48",
                "26",
                "1"
            );

            _store.SaveQuestion(
                "Qual é o prêmio que você ganha ao responder esta questão?", 3,
                "Glória eterna",
                "Um milhão de reais",
                "Mais perguntas",
                "Um lugar na tabela de pontuações"
            );

            _store.SaveQuestion(
                "Qual é o condimento que sabe de tudo?", 4,
                "Molho Shoyu",
                "O Vinagrete",
                "O Ketchup",
                "O Wasabi"
            );

            _store.SaveQuestion(
                "Pmpaprpqpupe pap prpepspppopsptpa pdpopipsp!p", 2,
                "1",
                "2",
                "3",
                "4"
            );

            _store.SaveQuestion(
                "Qual a razão da vida?", 4,
                "Comer",
                "Dormir",
                "Esbanjar no funk ostentação",
                "Finalizar o Crazy Quiz"
            );

            _store.SaveQuestion(
                "Qual famoso cientista tem os \"olhos nota 10\"?", 3,
                "Newton",
                "Darwin",
                "Einstein",
                "Galileu"
            );
        }
    }
}
