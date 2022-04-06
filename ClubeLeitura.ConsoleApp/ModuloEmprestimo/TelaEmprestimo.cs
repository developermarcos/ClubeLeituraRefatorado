using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.Compartilhado.Interfaces;
using ClubeLeitura.ConsoleApp.ModuloReserva;
using ClubeLeitura.ConsoleApp.ModuloMulta;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaEmprestimo : TelaBase
    {

        private Notificador notificador;
        private TelaAmigo telaAmigo;
        private TelaRevista telaRevista;
        private RepositorioEmprestimo repositorioEmprestimo;
        public RepositorioRevista repositorioRevista;
        public RepositorioAmigo repositorioAmigo;
        public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, TelaAmigo telaAmigo, TelaRevista telaRevista, Notificador notificador, RepositorioRevista repositorioRevista, RepositorioAmigo repositorioAmigo) : base ("Cadastro de Empréstimo")
        {
            this.repositorioEmprestimo=repositorioEmprestimo;
            this.telaAmigo=telaAmigo;
            this.telaRevista=telaRevista;
            this.notificador=notificador;
            this.repositorioRevista = repositorioRevista;
            this.repositorioAmigo = repositorioAmigo;
        }

        public TelaEmprestimo(
            Notificador notificador, 
            RepositorioEmprestimo repositorioEmprestimo, 
            RepositorioRevista repositorioRevista, 
            RepositorioAmigo repositorioAmigo, 
            TelaRevista telaRevista, 
            TelaAmigo telaAmigo) : base("Cadastro de Empréstimo")
        {
            this.repositorioEmprestimo=repositorioEmprestimo;
            this.telaAmigo=telaAmigo;
            this.telaRevista=telaRevista;
            this.notificador=notificador;
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

            bool existeAmigosCadastrados = telaAmigo.VisualizarRegistros("Pesquisando");

            if (!existeAmigosCadastrados)
            {
                notificador.ApresentarMensagem("Não existe amigos cadastrados!", TipoMensagem.Atencao);
                return;
            }

            bool existeRevistasCadastradas = telaRevista.Listar("Pesquisando");

            if (!existeRevistasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe revistas cadastradas!", TipoMensagem.Atencao);
                return;
            }

            Amigo amigoEmprestimo = ObterAmigo();

            Revista revistaEmprestimo = ObterRevista();

            Emprestimo emprestimoCadastro = ObterEmprestimo(amigoEmprestimo, revistaEmprestimo);


            repositorioEmprestimo.Inserir(emprestimoCadastro);

            notificador.ApresentarMensagem("Empréstimo inserido com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Empréstimo");

            bool temEmprestimosCadastrados = Listar("Pesquisando");

            if (temEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum emprétimo cadastrado para poder editar", TipoMensagem.Atencao);
                return;
            }

            bool existeAmigoCadastrado = telaAmigo.VisualizarRegistros("Pesquisando");

            if (!existeAmigoCadastrado)
            {
                notificador.ApresentarMensagem("Não existe amigo cadastrados!", TipoMensagem.Atencao);
                return;
            }

            bool existeRevistasCadastradas = telaRevista.Listar("Pesquisando");

            if (!existeRevistasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe emprétimos cadastrados!", TipoMensagem.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            Amigo amigoEmprestimo = ObterAmigo();

            Revista revistaEmprestimo = ObterRevista();

            Emprestimo emprestimoCadastro = ObterEmprestimo(amigoEmprestimo, revistaEmprestimo);

            repositorioEmprestimo.Editar(numeroEmprestimo, emprestimoCadastro);

            notificador.ApresentarMensagem("Empréstimo editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo emprétimo");

            bool temEmprestimosCadastrados = Listar("Pesquisando");

            if (temEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhum emprétimos cadastrado para poder excluir", TipoMensagem.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            repositorioEmprestimo.Excluir(numeroEmprestimo);

            notificador.ApresentarMensagem("Empréstimo excluído com sucesso", TipoMensagem.Sucesso);
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
                notificador.ApresentarMensagem("Nenhum emprétimo cadastrado.", TipoMensagem.Atencao);
                return;
            }

            int numeroEmprestimo = ObterNumeroEmprestimo();

            Emprestimo emprestimoDevolucao = repositorioEmprestimo.ObterRegistro(numeroEmprestimo);

            //if (emprestimoDevolucao.DataDevolucao < DateTime.Now)
            //{
            //    Multa multa = new Multa(emprestimoDevolucao);
            //    repositorioMulta.Inserir(multa);
            //    notificador.ApresentarMensagem("Uma multa foi gerada pelo atraso!", StatusValidacao.Atencao);
            //}

            repositorioEmprestimo.Devolucao(emprestimoDevolucao);

            notificador.ApresentarMensagem("Devolução realizada com sucesso!", TipoMensagem.Sucesso);
        }


        #region métodos privados

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
                    notificador.ApresentarMensagem("Número do empréstimo não encontrado, digite novamente", TipoMensagem.Atencao);

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
                    notificador.ApresentarMensagem("Número do amigo não encontrado, digite novamente", TipoMensagem.Atencao);

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
                    notificador.ApresentarMensagem("Número da revista não encontrado, digite novamente", TipoMensagem.Atencao);

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
                    notificador.ApresentarMensagem("Data não foi informada no padrão solicitado", TipoMensagem.Atencao);
            }
            Emprestimo emprestimo = new Emprestimo(amigoEmprestimo, revistaEmprestimo, emprestimoData);
            return emprestimo;
        }

        #endregion
    }
}
