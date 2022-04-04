using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.Compartilhado.Interfaces;
using ClubeLeitura.ConsoleApp.ModeloReserva;
using ClubeLeitura.ConsoleApp.ModuloMulta;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimos
{
    public class TelaEmprestimo : TelaBase, IEditavel, ICadastravel, IListavel
    {

        private Notificador notificador;
        private TelaAmigo telaAmigo;
        private TelaRevista telaRevista;
        private RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioMulta repositorioMulta;
        public RepositorioRevista repositorioRevista;
        public RepositorioAmigo repositorioAmigo;
        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, TelaAmigo telaAmigo, TelaRevista telaRevista, Notificador notificador, RepositorioRevista repositorioRevista, RepositorioAmigo repositorioAmigo)
        {
            this.repositorioEmprestimo=repositorioEmprestimo;
            this.telaAmigo=telaAmigo;
            this.telaRevista=telaRevista;
            this.notificador=notificador;
            this.repositorioMulta = null;
            this.repositorioRevista = repositorioRevista;
            this.repositorioAmigo = repositorioAmigo;
        }

        public override string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Empréstimos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Devolução");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void Inserir()
        {
            MostrarTitulo("Inserindo novo empréstimo");

            bool existeAmigosCadastrados = telaAmigo.Listar("Pesquisando");

            if (!existeAmigosCadastrados)
            {
                notificador.ApresentarMensagem("Não existe amigos cadastrados!", StatusValidacao.Atencao);
                return;
            }

            bool existeRevistasCadastradas = telaRevista.Listar("Pesquisando");

            if (!existeRevistasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe revistas cadastradas!", StatusValidacao.Atencao);
                return;
            }

            Amigo amigoEmprestimo = ObterAmigo();

            Revista revistaEmprestimo = ObterRevista();

            Emprestimo emprestimoCadastro = ObterEmprestimo(amigoEmprestimo, revistaEmprestimo);


            repositorioEmprestimo.Inserir(emprestimoCadastro);

            notificador.ApresentarMensagem("Empréstimo inserido com sucesso!", StatusValidacao.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Empréstimo");

            bool temEmprestimosCadastrados = Listar("Pesquisando");

            if (temEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum emprétimo cadastrado para poder editar", StatusValidacao.Atencao);
                return;
            }

            bool existeAmigoCadastrado = telaAmigo.Listar("Pesquisando");

            if (!existeAmigoCadastrado)
            {
                notificador.ApresentarMensagem("Não existe amigo cadastrados!", StatusValidacao.Atencao);
                return;
            }

            bool existeRevistasCadastradas = telaRevista.Listar("Pesquisando");

            if (!existeRevistasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe emprétimos cadastrados!", StatusValidacao.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            Amigo amigoEmprestimo = ObterAmigo();

            Revista revistaEmprestimo = ObterRevista();

            Emprestimo emprestimoCadastro = ObterEmprestimo(amigoEmprestimo, revistaEmprestimo);

            repositorioEmprestimo.Editar(numeroEmprestimo, emprestimoCadastro);

            notificador.ApresentarMensagem("Empréstimo editado com sucesso!", StatusValidacao.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo emprétimo");

            bool temEmprestimosCadastrados = Listar("Pesquisando");

            if (temEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum emprétimos cadastrado para poder excluir", StatusValidacao.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            repositorioEmprestimo.Excluir(numeroEmprestimo);

            notificador.ApresentarMensagem("Empréstimo excluído com sucesso", StatusValidacao.Sucesso);
        }

        public bool Listar(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de empréstimos");

            if (!repositorioEmprestimo.ExisteEmprestimoCadastrado())
                return false;

            Emprestimo[] emprestimos = repositorioEmprestimo.ObterTodosRegistros();

            if (emprestimos.Length == 0)
                return false;

            for (int i = 0; i < emprestimos.Length; i++)
            {
                Emprestimo e = emprestimos[i];

                Console.WriteLine(e.ToString());
                Console.WriteLine("Amigo - Nome: {0} | Responsável: {1} | Telefone: {2}", e.amigo.nome, e.amigo.responsavel, e.amigo.telefone);
                Console.WriteLine("Revista - Numero edição: {0} | Tipo coleção: {1}", e.revista.numeroEdicao, e.revista.tipoColecao);

                Console.WriteLine();
            }

            return true;
        }

        public void DevolucaoEmprestimo()
        {
            MostrarTitulo("Editando Empréstimo");

            bool temEmprestimosCadastrados = Listar("Pesquisando");

            if (temEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum emprétimo cadastrado.", StatusValidacao.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            Emprestimo emprestimoDevolucao = repositorioEmprestimo.ObterRegistro(numeroEmprestimo);

            if (emprestimoDevolucao.DataDevolucao < DateTime.Now)
            {
                Multa multa = new Multa(emprestimoDevolucao);
                repositorioMulta.Inserir(multa);
                notificador.ApresentarMensagem("Uma multa foi gerada pelo atraso!", StatusValidacao.Atencao);
            }

            repositorioEmprestimo.Devolucao(emprestimoDevolucao);

            notificador.ApresentarMensagem("Devolução realizada com sucesso!", StatusValidacao.Sucesso);
        }


        #region métodos privados

        private void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        private int ObterNumeroEmprestimo()
        {
            int numeroEmprestimo;
            bool numeroEmprestimoEncontrado;

            do
            {
                Console.Write("Digite o número do empréstimo que deseja editar: ");
                numeroEmprestimo = Convert.ToInt32(Console.ReadLine());

                numeroEmprestimoEncontrado = repositorioEmprestimo.ExisteNumeroRegistro(numeroEmprestimo);

                if (numeroEmprestimoEncontrado == false)
                    notificador.ApresentarMensagem("Número do empréstimo não encontrado, digite novamente", StatusValidacao.Atencao);

            } while (numeroEmprestimoEncontrado == false);

            return numeroEmprestimo;
        }

        private Amigo ObterAmigo()
        {
            int numeroAmigo;
            bool numeroAmigoEncontrado;

            do
            {
                Console.Write("Digite o número do amigo: ");
                numeroAmigo = Convert.ToInt32(Console.ReadLine());

                numeroAmigoEncontrado = repositorioAmigo.ExisteNumeroRegistro(numeroAmigo);

                if (numeroAmigoEncontrado == false)
                    notificador.ApresentarMensagem("Número do amigo não encontrado, digite novamente", StatusValidacao.Atencao);

            } while (numeroAmigoEncontrado == false);

            Amigo amigo = repositorioAmigo.ObterRegistro(numeroAmigo);
            return amigo;
        }

        private Revista ObterRevista()
        {
            int numeroRevista;
            bool numeroRevistaEncontrado;

            do
            {
                Console.Write("Digite o número da revista: ");
                numeroRevista = Convert.ToInt32(Console.ReadLine());

                numeroRevistaEncontrado = repositorioRevista.ExisteNumeroRegistro(numeroRevista);

                if (numeroRevistaEncontrado == false)
                    notificador.ApresentarMensagem("Número da revista não encontrado, digite novamente", StatusValidacao.Atencao);

            } while (numeroRevistaEncontrado == false);
            Revista revista = repositorioRevista.ObterRegistro(numeroRevista);
            return revista;
        }

        private Emprestimo ObterEmprestimo(Amigo amigoEmprestimo, Revista revistaEmprestimo)
        {
            Amigo amigo;
            Revista revista;
            DateTime emprestimoData;

            while (true)
            {
                Console.WriteLine("Informe a data do empréstimo (ex: 00/00/0000): ");
                string dataEmprestimo = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(dataEmprestimo, out DateTime dataCadastro);
                if (dataEmprestimo.Length == 10 && conversaoRealizada == true)
                {
                    amigo = amigoEmprestimo;
                    revista = revistaEmprestimo;
                    emprestimoData = dataCadastro;
                    break;
                }
                else
                    notificador.ApresentarMensagem("Data não foi informada no padrão solicitado", StatusValidacao.Atencao);
            }
            Emprestimo emprestimo = new Emprestimo(amigoEmprestimo, revistaEmprestimo, emprestimoData);
            return emprestimo;
        }

        #endregion
    }
}
