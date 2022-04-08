using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.Compartilhado.Interfaces;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloPessoa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.ModuloReserva
{
    public class TelaReserva : TelaBase
    {
        public Notificador notificador; 

        private RepositorioReserva repositorioReserva;
        private TelaEmprestimo telaEmprestimo;
        private TelaAmigo telaAmigo;
        private RepositorioAmigo repositorioAmigo;
        private TelaRevista telaRevista;
        private RepositorioRevista repositorioRevista;
        private RepositorioEmprestimo repositorioEmprestimo;

        public TelaReserva(
            RepositorioReserva repositorioReserva,
            TelaAmigo telaAmigo,
            TelaRevista telaRevista,
            TelaEmprestimo telaEmprestimo,
            Notificador notificador,
            RepositorioAmigo repositorioAmigo,
            RepositorioRevista repositorioRevista,
            RepositorioEmprestimo repositorioEmprestimo) : base("Tela Reserva")
        {
            this.repositorioReserva=repositorioReserva;
            this.telaAmigo=telaAmigo;
            this.telaRevista=telaRevista;
            this.telaEmprestimo=telaEmprestimo;
            this.notificador=notificador;
            this.repositorioAmigo=repositorioAmigo;
            this.repositorioRevista=repositorioRevista;
            this.repositorioEmprestimo=repositorioEmprestimo;
        }

        public TelaReserva(Notificador notificador, RepositorioReserva repositorioReserva, RepositorioAmigo repositorioAmigo, RepositorioRevista repositorioRevista, TelaAmigo telaAmigo, TelaRevista telaRevista, RepositorioEmprestimo repositorioEmprestimo) : base("Tela Reserva")
        {
            this.notificador=notificador;
            this.repositorioReserva=repositorioReserva;
            this.repositorioAmigo=repositorioAmigo;
            this.repositorioRevista=repositorioRevista;
            this.telaAmigo=telaAmigo;
            this.telaRevista=telaRevista;
            this.repositorioEmprestimo=repositorioEmprestimo;
        }

        public override string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Reservas");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Registrar Reserva");
            Console.WriteLine("Digite 2 para Visualizar");
            Console.WriteLine("Digite 3 para Visualizar Reservas em Aberto");
            Console.WriteLine("Digite 4 para Cadastrar um Empréstimo à partir de Reserva");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void Registrar()
        {
            MostrarTitulo("Inserindo nova reserva");

            bool existeAmigosCadastrados = telaAmigo.VisualizarRegistros("Pesquisando");

            if (!existeAmigosCadastrados)
            {
                notificador.ApresentarMensagem("Não existe amigos cadastrados!", TipoMensagem.Atencao);
                return;
            }

            Amigo amigoReserva = ObterAmigo();

            bool existeRevistasCadastradas = telaRevista.VisualizarRegistros("Pesquisando");

            if (!existeRevistasCadastradas)
            {
                notificador.ApresentarMensagem("Não existe revistas cadastradas!", TipoMensagem.Atencao);
                return;
            }

            Revista revistaReserva = ObterRevista();

            Reserva reservaCadastro = ObterReserva(amigoReserva, revistaReserva);

            repositorioReserva.Inserir(reservaCadastro);

            notificador.ApresentarMensagem("Empréstimo inserido com sucesso!", TipoMensagem.Sucesso);
        }

        public bool Visualizar(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de reservas");
            Reserva[] reservas = repositorioReserva.ObterTodosRegistros();
            if (reservas.Length == 0)
                return false;

            for (int i = 0; i < reservas.Length; i++)
            {
                Reserva r = reservas[i];

                Console.WriteLine();

                Console.WriteLine(r.ToString());
                Console.WriteLine("Amigo - Nome: {0} | Responsável: {1} | Telefone: {2}", r.amigo.nome, r.amigo.responsavel, r.amigo.telefone);
                Console.WriteLine("Revista - Numero edição: {0} | Tipo coleção: {1}", r.revista.numeroEdicao, r.revista.tipoColecao);


                Console.WriteLine();
            }

            return true;
        }

        public bool VisualizarReservasEmAberto(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de reservas");

            if (repositorioReserva.ObterTodosRegistros().Length == 0)
                return false;

            Reserva[] reservas = repositorioReserva.ObterTodosRegistros();

            if (reservas.Length == 0)
                return false;

            for (int i = 0; i < reservas.Length; i++)
            {
                Reserva r = reservas[i];

                Console.WriteLine();

                Console.WriteLine(r.ToString());
                Console.WriteLine("Amigo - Nome: {0} | Responsável: {1} | Telefone: {2}", r.amigo.nome, r.amigo.responsavel, r.amigo.telefone);
                Console.WriteLine("Revista - Numero edição: {0} | Tipo coleção: {1}", r.revista.numeroEdicao, r.revista.tipoColecao);


                Console.WriteLine();
            }

            return true;
        }

        public void EmprestimoApartirReserva()
        {
            MostrarTitulo("Inserindo novo empréstimo");

            bool temeEmprestimosCadastrados = Visualizar("Pesquisando");
            if (temeEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhuma reserva cadastrado para poder editar", TipoMensagem.Atencao);
                return;
            }

            Console.WriteLine("Informe a reserva que deseja criar um empréstimo");
            int numeroReserva = ObterNumeroReserva();

            Reserva reserva = (Reserva)repositorioReserva.ObterRegistro(numeroReserva);

            Emprestimo novoEmprestimo = new Emprestimo(reserva.amigo, reserva.revista, DateTime.Now);

            repositorioEmprestimo.Inserir(novoEmprestimo);

            //repositorioReserva.InativarRegistro(numeroReserva);

            notificador.ApresentarMensagem("Empréstimo realizado com sucesso", TipoMensagem.Sucesso);
        }

        private void Inativar()
        {
            MostrarTitulo("Inativando reserva");

            bool temeEmprestimosCadastrados = Visualizar("Pesquisando");
            if (temeEmprestimosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhuma reserva cadastrado para poder inativar", TipoMensagem.Atencao);
                return;
            }

            Console.WriteLine("Informe a reserva que deseja inativar");
            int numeroReserva = ObterNumeroReserva();

            //repositorioReserva.InativarRegistro(numeroReserva);
            notificador.ApresentarMensagem("Reserva inativada com sucesso!", TipoMensagem.Sucesso);
        }


        #region métodos privados
        
        private Reserva ObterReserva(Amigo amigoEmprestimo, Revista revistaEmprestimo)
        {
            Amigo amigo;
            Revista revista;
            DateTime reservaData;

            while (true)
            {
                Console.Write("Informe a data da reserva (ex: 00/00/0000): ");
                string dataEmprestimo = Console.ReadLine();
                bool conversaoRealizada = DateTime.TryParse(dataEmprestimo, out DateTime dataCadastro);
                if (dataEmprestimo.Length == 10 && conversaoRealizada == true)
                {
                    amigo = amigoEmprestimo;
                    revista = revistaEmprestimo;
                    reservaData = dataCadastro;
                    break;
                }
                else
                    notificador.ApresentarMensagem("Data não foi informada no padrão solicitado, tente novamente.", TipoMensagem.Atencao);
            }
            Reserva emprestimo = new Reserva(amigoEmprestimo, revistaEmprestimo, reservaData);
            return emprestimo;
        }

        private int ObterNumeroReserva()
        {
            int numeroReserva;
            bool numeroReservaEncontrada;

            do
            {
                Console.Write("Digite o número da reserva: ");
                numeroReserva = Convert.ToInt32(Console.ReadLine());

                numeroReservaEncontrada = repositorioReserva.RegistroExiste(numeroReserva);

                if (numeroReservaEncontrada == false)
                    notificador.ApresentarMensagem("Número da reserva não encontrada, digite novamente", TipoMensagem.Atencao);

            } while (numeroReservaEncontrada == false);

            return numeroReserva;
        }

        private Amigo ObterAmigo()
        {
            int numeroAmigo;
            bool numeroAmigoEncontrado;

            do
            {
                Console.Write("Digite o número do amigo: ");
                numeroAmigo = Convert.ToInt32(Console.ReadLine());

                numeroAmigoEncontrado = repositorioAmigo.RegistroExiste(numeroAmigo);

                if (numeroAmigoEncontrado == false)
                    notificador.ApresentarMensagem("Número do amigo não encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroAmigoEncontrado == false);


            Amigo amigo = repositorioAmigo.ObterRegistro(numeroAmigo);
            return amigo;
        }

        public Revista ObterRevista()
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

            Revista revista = repositorioRevista.ObterRegistro(numeroRevista);
            return revista;
        }

        #endregion
    }
}
