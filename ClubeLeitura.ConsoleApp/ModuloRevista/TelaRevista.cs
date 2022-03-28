using System;
using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class TelaRevista
    {
        public int numeroCaixa; //controlar o número da caixas cadastradas
        public Notificador notificador; //reponsável pelas mensagens pro usuário
        public RepositorioRevista repositorioRevista;
        
        public TelaCaixa telaCaixa;
        public RepositorioCaixa repositorioCaixa;


        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Revistas");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovaRevista()
        {
            MostrarTitulo("Inserindo nova Revista");

            bool existeCaixasCadastradas = telaCaixa.VisualizarCaixas("Pesquisando");

            if (!existeCaixasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe caixas cadastradas!", StatusValidacao.Atencao);
                return;
            }
            Caixa caixa = ObterCaixa();

            Revista novaRevista = ObterRevista(caixa);

            repositorioRevista.Inserir(novaRevista);

            notificador.ApresentarMensagem("Revista inserida com sucesso!", StatusValidacao.Sucesso);
        }

        public void EditarRevista()
        {
            MostrarTitulo("Editando Caixa");

            bool temRevistasCadastradas = VisualizarRevistas("Pesquisando");

            if (temRevistasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma revista cadastrada para poder editar", StatusValidacao.Atencao);
                return;
            }

            int numeroRevista = ObterNumeroRevista();

            bool existeCaixasCadastradas = telaCaixa.VisualizarCaixas("Pesquisando");

            if (!existeCaixasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe caixas cadastradas!", StatusValidacao.Atencao);
                return;
            }

            Caixa caixaAtualizada = ObterCaixa();
            Revista revistaAtualizada = ObterRevista(caixaAtualizada);

            repositorioRevista.Editar(numeroRevista, revistaAtualizada);

            notificador.ApresentarMensagem("Caixa editada com sucesso", StatusValidacao.Sucesso);
        }

        public void ExcluirRevista()
        {
            MostrarTitulo("Excluindo revista");

            bool temRevistasCadastradas = VisualizarRevistas("Pesquisando");

            if (temRevistasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma revista cadastrada para poder excluir", StatusValidacao.Atencao);
                return;
            }

            int numeroRevista = ObterNumeroRevista();

            repositorioRevista.Excluir(numeroRevista);

            notificador.ApresentarMensagem("Revista excluída com sucesso", StatusValidacao.Sucesso);
        }

        public int ObterNumeroRevista()
        {
            int numeroRevista;
            bool numeroRevistaEncontrado;

            do
            {
                Console.Write("Digite o número da revista: ");
                numeroRevista = Convert.ToInt32(Console.ReadLine());

                numeroRevistaEncontrado = repositorioRevista.VerificarNumeroRevistaExiste(numeroRevista);

                if (numeroRevistaEncontrado == false)
                    notificador.ApresentarMensagem("Número da revista não encontrado, digite novamente", StatusValidacao.Atencao);

            } while (numeroRevistaEncontrado == false);

            return numeroRevista;
        }

        public Caixa ObterCaixa()
        {
            Caixa caixa = null;
            bool caixaExiste;
                        
            do
            {
                Console.Write("Informe a caixa para armazenar a revista: ");
                int numeroCaixa = Convert.ToInt32(Console.ReadLine());
                caixaExiste = repositorioCaixa.VerificarNumeroCaixaExiste(numeroCaixa);
                caixa = null;
                if (caixaExiste)
                    caixa = repositorioCaixa.ObterCaixa(numeroCaixa);
                else
                    notificador.ApresentarMensagem("Caixa não encontrada, informe novamente", StatusValidacao.Erro);

            } while (!caixaExiste);

            return caixa;
        }

        public Revista ObterRevista(Caixa caixa)
        {
            Console.Write("Digite o tipo da coleção: ");
            string tipoColecao = Console.ReadLine();

            Console.Write("Digite o numero da edição: ");
            string numeroEdicao = Console.ReadLine();

            Console.Write("Digite o ano: ");
            string ano = Console.ReadLine();

            Revista revista = new Revista();

            revista.tipoColecao = tipoColecao;
            revista.numeroEdicao = numeroEdicao;
            revista.ano = ano;
            revista.caixa = caixa;

            return revista;
        }

        public bool VisualizarRevistas(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Revistas");

            Revista[] revistas = repositorioRevista.SelecionarTodos();

            if (revistas.Length == 0)
                return false;

            for (int i = 0; i < revistas.Length; i++)
            {
                Revista r = revistas[i];

                Console.WriteLine("Número: " + r.numero);
                Console.WriteLine("Tipo da coleção: " + r.tipoColecao);
                Console.WriteLine("Ano: " + r.ano);
                Console.WriteLine("Edição: " + r.numeroEdicao);
                Console.WriteLine("Caixa Etiqueta: " + r.caixa.etiqueta);
                Console.WriteLine("Caixa Cor: " + r.caixa.cor);
                

                Console.WriteLine();
            }

            return true;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
        
    }
}
