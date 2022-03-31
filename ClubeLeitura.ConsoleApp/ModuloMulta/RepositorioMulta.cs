using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloMulta
{
    public class RepositorioMulta
    {
        public int numero;
        Multa[] multas;
        
        public RepositorioMulta(Multa[] multas)
        {
            this.multas = multas;
        }

        public void Inserir(Multa multa)
        {
            multa.numero = ++numero;
            int posicaoVazia = ObterPosicaoVazia();
            multas[posicaoVazia] = multa;
        }

        private int ObterPosicaoVazia()
        {
            for (int i = 0; i < multas.Length; i++)
            {
                if(multas[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
        public Multa[] SelecionarTodos()
        {
            int quantidadeMultas = ObterQtdMultas();

            Multa[] multasInseridas = new Multa[quantidadeMultas];
            int j = 0;
            for (int i = 0; i < multas.Length; i++)
            {
                if (multas[i] != null)
                {
                    multasInseridas[j] = multas[i];
                    j++;
                }
            }

            return multasInseridas;
        }

        private int ObterQtdMultas()
        {
            int quantidadeMultas = 0;

            for (int i = 0; i < multas.Length; i++)
            {
                if(multas[i] != null)
                    quantidadeMultas++;
            }

            return quantidadeMultas;
        }

        public bool MultaCadastrada(int numero)
        {
            for (int i = 0; i < multas.Length; i++)
            {
                if (multas[i].numero == numero)
                    return true;
            }

            return false;
        }

        public Multa SelecionaMulta(int numero)
        {
            Multa multa = null;

            for (int i = 0; i < multas.Length; i++)
            {
                if (multas[i].numero == numero)
                    return multas[i];
            }

            return multa;
        }

        public void BaixarMulta(int numero)
        {
            for (int i = 0; i < multas.Length; i++)
            {
                if (multas[i].numero == numero)
                {
                    multas[i].fechada = true;
                    break;
                }
            }
        }

        public bool ExisteMultaAmigo(int numero)
        {
            for (int i = 0; i < multas.Length; i++)
            {
                if (multas[i] != null && multas[i].numero == numero)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
