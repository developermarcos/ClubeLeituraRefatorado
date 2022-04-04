using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.Compartilhado.Interfaces;
using ClubeLeitura.ConsoleApp.ModuloMulta;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    public class TelaAmigo : TelaBase, IEditavel, ICadastravel, IListavel, IExcluivel
    {
        public Notificador notificador; //reponsável pelas mensagens pro usuário
        public RepositorioAmigo repositorioAmigo;
        public TelaMulta telaMulta;
        public RepositorioMulta repositorioMulta;

        public TelaAmigo(RepositorioAmigo repositorioAmigo, Notificador notificador)
        {
            this.repositorioAmigo=repositorioAmigo;
            this.notificador=notificador;
            this.telaMulta = null;
            this.repositorioMulta = null;
        }

        public override string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para Multas");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void Inserir()
        {
            MostrarTitulo("Inserindo novo Amigo");

            Amigo novoAmigo = ObterAmigo();

            repositorioAmigo.Inserir(novoAmigo);

            notificador.ApresentarMensagem("Amigo inserido com sucesso!", StatusValidacao.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Amigo");

            bool temCaixasCadastradas = Listar("Pesquisando");

            if (temCaixasCadastradas == false)
            {
                notificador.ApresentarMensagem("Nenhum amigo cadastrado para poder editar", StatusValidacao.Atencao);
                return;
            }

            int numeroCaixa = ObterNumeroAmigo();

            Amigo amigoAtualizado = ObterAmigo();

            repositorioAmigo.Editar(numeroCaixa, amigoAtualizado);

            notificador.ApresentarMensagem("Amigo editado com sucesso", StatusValidacao.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Amigo");

            bool temCaixasCadastradas = Listar("Pesquisando");

            if (temCaixasCadastradas == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhum amigo cadastrado para poder excluir", StatusValidacao.Atencao);
                return;
            }

            int numeroAmigo = ObterNumeroAmigo();

            repositorioAmigo.Excluir(numeroAmigo);

            notificador.ApresentarMensagem("Amigo excluído com sucesso", StatusValidacao.Sucesso);
        }

        public bool Listar(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            Amigo[] amigos = repositorioAmigo.ObterTodosRegistros();

            if (amigos.Length == 0)
                return false;

            for (int i = 0; i < amigos.Length; i++)
            {
                Amigo a = amigos[i];

                Console.WriteLine();

                Console.WriteLine(a.ToString());

                Console.WriteLine();
            }

            return true;
        }

        public void BaixarMulta()
        {
            MostrarTitulo("Baixar multa");
            if (telaMulta == null)
            {
                notificador.ApresentarMensagem("Nenhuma multa cadastrada para poder editar", StatusValidacao.Atencao);
                return;
            }

            bool temMultasCadastras = telaMulta.Listar("Pesquisando");

            if (temMultasCadastras == false)
            {
                notificador.ApresentarMensagem("Nenhuma multa cadastrada para poder editar", StatusValidacao.Atencao);
                return;
            }

            int numeroBaixa = obterNumeroMulta();

            repositorioMulta.BaixarMulta(numeroBaixa);

            notificador.ApresentarMensagem("Multa baixada com sucesso!", StatusValidacao.Sucesso);
        }

        #region métodos internos
        private Amigo ObterAmigo()
        {
            string nome;
            bool nomeJaUtilizado;
            do
            {
                nomeJaUtilizado = false;

                Console.Write("Digite o nome: ");
                nome = Console.ReadLine();

                nomeJaUtilizado = repositorioAmigo.nomeJaCadastrado(nome);

                if (nomeJaUtilizado)
                    notificador.ApresentarMensagem("Nome já cadastrado, por gentileza informe outro", StatusValidacao.Erro);

            } while (nomeJaUtilizado);

            Console.Write("Digite o responsável: ");
            string responsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(nome, responsavel, telefone, endereco);

            return amigo;
        }

        private void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        private int obterNumeroMulta()
        {
            int numero = default;
            bool multaEncontrada;
            do
            {
                Console.Write("Digite o numero da multa para baixar: ");
                numero = Convert.ToInt32(Console.ReadLine());

                multaEncontrada = repositorioMulta.ExisteNumeroRegistro(numero);

                if (!multaEncontrada)
                    notificador.ApresentarMensagem("Numero da multa não encontrado, informe novamente.", StatusValidacao.Erro);
                else
                {
                    return numero;
                }

            } while (!multaEncontrada);

            return numero;
        }

        private int ObterNumeroAmigo()
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

            return numeroAmigo;
        }

        #endregion
    }
}
