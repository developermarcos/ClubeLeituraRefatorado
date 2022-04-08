using System;
using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.Compartilhado.Interfaces;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloCategoriaRevista;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class TelaRevista : TelaBase, ICadastroBasico
    {
        public int numeroCaixa; //controlar o número da caixas cadastradas
        public Notificador notificador; //reponsável pelas mensagens pro usuário
        
        public RepositorioRevista repositorioRevista;

        private TelaCategoriaRevista telaCategoria;
        private RepositorioCategoriaRevista repositorioCategoria;

        private TelaCaixa telaCaixa;
        private RepositorioCaixa repositorioCaixa;

        public TelaRevista(TelaCaixa telaCaixa, TelaCategoriaRevista telaCategoria, RepositorioCategoriaRevista repositorioCategoria, RepositorioCaixa repositorioCaixa, RepositorioRevista repositorioRevista, Notificador notificador) : base("Tela Revista")
        {
            this.telaCaixa = telaCaixa;
            this.telaCategoria = telaCategoria;
            this.repositorioCaixa=repositorioCaixa;
            this.repositorioRevista=repositorioRevista;
            this.repositorioCategoria = repositorioCategoria;
            this.notificador=notificador;
        }

        
        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo nova Revista");

            bool existeCategoriaCadastrada = telaCategoria.VisualizarRegistros("pesquisando");

            if (!existeCategoriaCadastrada)
            {
                notificador.ApresentarMensagem("Não existe categorias cadastradas!", TipoMensagem.Atencao);
                return;
            }

            CategoriaRevista categoria = ObterCategoria();

            bool existeCaixasCadastradas = telaCaixa.VisualizarRegistros("Pesquisando");

            if (!existeCaixasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe caixas cadastradas!", TipoMensagem.Atencao);
                return;
            }

            Caixa caixa = ObterCaixa();

            Revista novaRevista = ObterRevista(caixa, categoria);

            repositorioRevista.Inserir(novaRevista);

            notificador.ApresentarMensagem("Revista inserida com sucesso!", TipoMensagem.Sucesso);
        }

        public void EditarRegistro()
        {
            MostrarTitulo("Editando Caixa");

            bool temRevistasCadastradas = VisualizarRegistros("Pesquisando");

            if (temRevistasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma revista cadastrada para poder editar", TipoMensagem.Atencao);
                return;
            }

            int numeroRevista = ObterNumeroRevista();

            bool existeCategoriaCadastrada = telaCategoria.VisualizarRegistros("pesquisando");

            if (!existeCategoriaCadastrada)
            {
                notificador.ApresentarMensagem("Não existe categorias cadastradas!", TipoMensagem.Atencao);
                return;
            }

            bool existeCaixasCadastradas = telaCaixa.VisualizarRegistros("Pesquisando");

            CategoriaRevista categoria = ObterCategoria();

            if (!existeCaixasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe caixas cadastradas!", TipoMensagem.Atencao);
                return;
            }

            Caixa caixaAtualizada = ObterCaixa();

            Revista revistaAtualizada = ObterRevista(caixaAtualizada, categoria);

            repositorioRevista.Editar(numeroRevista, revistaAtualizada);

            notificador.ApresentarMensagem("Caixa editada com sucesso", TipoMensagem.Sucesso);
        }

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluindo revista");

            bool temRevistasCadastradas = VisualizarRegistros("Pesquisando");

            if (temRevistasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhuma revista cadastrada para poder excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroRevista = ObterNumeroRevista();

            repositorioRevista.Excluir(numeroRevista);

            notificador.ApresentarMensagem("Revista excluída com sucesso", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Revistas");

            Revista[] revistas = (Revista[])repositorioRevista.ObterTodosRegistros();

            if (revistas.Length == 0)
                return false;

            for (int i = 0; i < revistas.Length; i++)
            {
                Revista r = revistas[i];

                Console.WriteLine();

                Console.WriteLine(r.ToString());
                Console.WriteLine("Categoria: {0}", r.categoria.nome);

                Console.WriteLine();
            }

            return true;
        }
        

        #region métodos privados

        private Caixa ObterCaixa()
        {
            Caixa caixa = null;
            bool caixaExiste;

            do
            {
                Console.Write("Informe a caixa para armazenar a revista: ");
                int numeroCaixa = Convert.ToInt32(Console.ReadLine());
                caixaExiste = repositorioCaixa.RegistroExiste(numeroCaixa);
                caixa = null;
                if (caixaExiste)
                    caixa = repositorioCaixa.ObterRegistro(numeroCaixa);
                else
                    notificador.ApresentarMensagem("Caixa não encontrada, informe novamente", TipoMensagem.Atencao);

            } while (!caixaExiste);

            return caixa;
        }

        private Revista ObterRevista(Caixa caixa, CategoriaRevista categoria)
        {
            Console.Write("Digite o tipo da coleção: ");
            string tipoColecao = Console.ReadLine();

            Console.Write("Digite o numero da edição: ");
            string numeroEdicao = Console.ReadLine();

            Console.Write("Digite o ano: ");
            string ano = Console.ReadLine();

            Revista revista = new Revista(tipoColecao, numeroEdicao, ano, caixa, categoria);

            return revista;
        }

        private int ObterNumeroRevista()
        {
            int numeroRevista;
            bool numeroRevistaEncontrado;

            do
            {
                Console.Write("Digite o número da revista: ");
                numeroRevista = Convert.ToInt32(Console.ReadLine());

                numeroRevistaEncontrado = repositorioRevista.RegistroExiste(numeroRevista);

                if (numeroRevistaEncontrado == false)
                    notificador.ApresentarMensagem("Número da revista não encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRevistaEncontrado == false);

            return numeroRevista;
        }

        private CategoriaRevista ObterCategoria()
        {
            int numeroCategoria;
            bool numeroCategoriaEncontrada;

            do
            {
                Console.Write("Digite o número da categoria: ");
                numeroCategoria = Convert.ToInt32(Console.ReadLine());

                numeroCategoriaEncontrada = telaCategoria.repositorioCategoriaRevista.RegistroExiste(numeroCategoria);

                if (numeroCategoriaEncontrada == false)
                    notificador.ApresentarMensagem("Número da categoria não encontrada, digite novamente", TipoMensagem.Atencao);

            } while (numeroCategoriaEncontrada == false);

            CategoriaRevista categoria = telaCategoria.repositorioCategoriaRevista.ObterRegistro(numeroCategoria);
            return categoria;
        }

        #endregion
    }
}
