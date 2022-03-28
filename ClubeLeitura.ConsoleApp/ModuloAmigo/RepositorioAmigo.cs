using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloPessoa
{
    internal class RepositorioAmigo
    {
        public Amigo[] amigos;
        public int numeroAmigo;

        public void Inserir(Amigo amigo)
        {
            amigo.numero = ++numeroAmigo;

            int posicaoVazia = ObterPosicaoVazia();
            amigos[posicaoVazia] = amigo;
        }

        public void Editar(int numeroSelecioando, Amigo amigo)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].numero == numeroSelecioando)
                {
                    amigo.numero = numeroSelecioando;
                    amigos[i] = amigo;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].numero == numeroSelecionado)
                {
                    amigos[i] = null;
                    break;
                }
            }
        }

        public bool nomeJaCadastrado(string nomeInformado)
        {
            bool nomejaUtilizado = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].nome == nomeInformado)
                {
                    nomejaUtilizado = true;
                    break;
                }
            }

            return nomejaUtilizado;
        }

        public bool VerificarNumeroAmigoExiste(int numeroAmigo)
        {
            bool numeroAmigoEncontrado = false;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null && amigos[i].numero == numeroAmigo)
                {
                    numeroAmigoEncontrado = true;
                    break;
                }
            }

            return numeroAmigoEncontrado;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }

        public Amigo[] SelecionarTodos()
        {
            int quantidadeAmigos = ObterQtdAmigos();

            Amigo[] amigosInseridos = new Amigo[quantidadeAmigos];
            int j = 0;
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    amigosInseridos[j] = amigos[i];
                    j++;
                }
            }

            return amigosInseridos;
        }

        internal Amigo ObterAmigo(int idAmigo)
        {
            Amigo amigo = null;

            for (int i = 0; i < amigos.Length; i++)
            {
                if(amigos[i] != null && amigos[i].numero == idAmigo)
                {
                    amigo = amigos[i];
                    break;
                }
            }

            return amigo;
        }

        public int ObterQtdAmigos()
        {
            int numeroAmigos = 0;

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                    numeroAmigos++;
            }

            return numeroAmigos;
        }
        public void PopularAmigos(string nome, string responsavel, string telefone, string endereco)
        {
            Amigo amigo= new Amigo();
            amigo.nome = nome;
            amigo.responsavel = responsavel;
            amigo.telefone = telefone;
            amigo.endereco = endereco;
            Inserir(amigo);
        }

    }
}
