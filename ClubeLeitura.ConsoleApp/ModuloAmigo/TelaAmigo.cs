using ClubeLeitura.ConsoleApp.Compartilhado;
using System;

namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    internal class TelaAmigo
    {
        public int numeroAmigo; //controlar o número de amigos cadastrados
        public Notificador notificador; //reponsável pelas mensagens pro usuário
        public RepositorioAmigo repositorioAmigo;
        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Caixas");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo novo Amigo");

            Amigo novoAmigo = ObterAmigo();

            repositorioAmigo.Inserir(novoAmigo);

            notificador.ApresentarMensagem("Amigo inserido com sucesso!", StatusValidacao.Sucesso);
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");

            bool temCaixasCadastradas = VisualizarAmigos("Pesquisando");

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

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            bool temCaixasCadastradas = VisualizarAmigos("Pesquisando");

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

        public bool VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Amigos");

            Amigo[] amigos = repositorioAmigo.SelecionarTodos();

            if (amigos.Length == 0)
                return false;

            for (int i = 0; i < amigos.Length; i++)
            {
                Amigo a = amigos[i];

                Console.WriteLine("ID: " + a.Numero);
                Console.WriteLine("Nome: " + a.Nome);
                Console.WriteLine("Responsavel: " + a.Responsavel);
                Console.WriteLine("Telefone: " + a.Telefone);
                Console.WriteLine("Endereço: " + a.Endereco);

                Console.WriteLine();
            }

            return true;
        }
        
        public Amigo ObterAmigo()
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

        public int ObterNumeroAmigo()
        {
            int numeroAmigo;
            bool numeroAmigoEncontrado;

            do
            {
                Console.Write("Digite o número do amigo: ");
                numeroAmigo = Convert.ToInt32(Console.ReadLine());

                numeroAmigoEncontrado = repositorioAmigo.VerificarNumeroAmigoExiste(numeroAmigo);

                if (numeroAmigoEncontrado == false)
                    notificador.ApresentarMensagem("Número do amigo não encontrado, digite novamente", StatusValidacao.Atencao);

            } while (numeroAmigoEncontrado == false);

            return numeroAmigo;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
    }
}
