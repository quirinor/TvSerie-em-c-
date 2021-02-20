using System;


namespace tvseries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string OpcaoDoUsuario = obterOpcaoDoUsuario();

            while(OpcaoDoUsuario.ToUpper()!="X")
            {
                switch(OpcaoDoUsuario)
                {
                    case "1":
                    listarSeries();
                    break;
                     case "2":
                    InserirSerie();
                    break;
                     case "3":
                    AtualizarSerie();
                    break;
                     case "4":
                    ExcluirSerie();
                    break;
                     case "5":
                    VisualizarSerie();
                    break;
                     case "C":
                    Console.Clear();
                    break;
                    default:
                        throw new ArgumentOutOfRangeException();


                }


            OpcaoDoUsuario = obterOpcaoDoUsuario();


            }




        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da serie que deseja excluir");
            int indiceDaSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceDaSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da Serie que deseja visualizar");
            int indiceDaSerie = int.Parse(Console.ReadLine());

            var infoserie = repositorio.RetornaPorId(indiceDaSerie);
            Console.WriteLine(infoserie);
        }


        private static void listarSeries()
        {

            Console.WriteLine("Lista de Séries:");
            var lista=repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Não existe series cadastradas");
                return;
            }
            foreach(var serie in lista)
            {
                var Excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} - {2}",serie.retornaId(), serie.retornaTitulo(), (Excluido?"Serie Excluida":""));
            }          
                           

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir série :)");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genero),i));

            }
            Console.WriteLine("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série");
            string entradaDescricao = Console.ReadLine();

            Series NovaSerie = new Series(id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Insere(NovaSerie);

        }

        private static void AtualizarSerie()
        {

            Console.WriteLine("Digite o ID da série que deseja atualizar");
            int indiceDaSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof (Genero)))
            {
               Console.WriteLine("{0}-{1}",i,Enum.GetName(typeof(Genero),i)); 
            }

            Console.WriteLine("Digite o Genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série");
            string entradaDescricao = Console.ReadLine();

            Series AtuSerie = new Series(id: indiceDaSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Atualiza(indiceDaSerie, AtuSerie);



        }


        private static string obterOpcaoDoUsuario()
        {
            Console.WriteLine("1 - listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("c - Limpar Tela");
            Console.WriteLine("x - Sair");
            Console.WriteLine();

            string OpcaoDoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoDoUsuario;

        }




    }
}
