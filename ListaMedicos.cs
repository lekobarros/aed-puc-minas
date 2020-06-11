using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_CLIN_MED
{
    public class No
    {
        public Medico elemento;
        public No prox;

        public No(Medico novo)
        {
            this.elemento = novo;
            this.prox = null;
        }

        public No()
        {

            elemento = new Medico("00000", "Vazio", -1);
            prox = null;
        }
    }

    class ListaMedico
    {
        No Primeiro;
        int contador;

        public ListaMedico()
        {
            Primeiro = new No();
            contador = 0;
        }

        public bool Inserir(Medico novo)
        {
            try
            {
                No aux = Primeiro;

                while (aux.prox != null)
                {
                    aux = aux.prox;
                }
                aux.prox = new No(novo);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Medico Remover(string chave)
        {
            try
            {
                No aux = Primeiro.prox;
                No aux2 = Primeiro;

                while (aux != null)
                {
                    if (aux.elemento.crm == chave)
                    {
                        No Retorno = aux;
                        aux2.prox = aux.prox;
                        aux.prox = null;
                        return aux.elemento;
                    }

                    aux2 = aux2.prox;
                    aux = aux.prox;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public Medico Procurar(string chave)
        {
            try
            {
                No aux = Primeiro.prox;

                while (aux != null)
                {
                    if (aux.elemento.crm == chave)
                    {
                        return aux.elemento;
                    }
                    aux = aux.prox;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Medico RemoverPrimeiro()
        {
            No Retirar = Primeiro.prox;
            Primeiro.prox = Retirar.prox;
            Retirar.prox = null;
            return Retirar.elemento;
        }

        public int contarMedicos ()
        {
            int count = 0;
            No aux = Primeiro.prox;

            while (aux != null)
            {
                count++;
                aux = aux.prox;
            }
            return count;
        }


        public Medico[] retornaLista()
        {
            int totalMed = this.contarMedicos();
            int index = 0;

            No aux = Primeiro.prox;
            Medico[] vetMed = new Medico[totalMed];

            while (aux != null && index < vetMed.Length)
            {
                vetMed[index] = aux.elemento;
                index++;
                aux = aux.prox;
            }

            return vetMed;
        }

        public void imprime()
        {
            // Varrer a lista de médicos e fazer uma contagem dos valores recebidos
            // Inserir o médico em alguma estrutura de dados ==
            // Usar o QuickSort em uma estrutura com a chave da soma de valores
            // Imprimir os valores da ordenação do quicksort


            // [1, 2, 3 ...]
            // pegar o aux e add no queue
            // aux.atendimentoAgendado * 35 e aux.atendimentoDemanda * 40
            // medico com valor 
            // quicksort medico.totalValor
            No aux = Primeiro.prox;
            // Medico listaDeMed = new Medico<>();
            List<Medico> PersonList = new List<Medico>();
            int valorTotal = 0;
            // Medico: Nome;valor

            while (aux != null)
            {
                PersonList.Add(aux.elemento);
                valorTotal = valorTotal + aux.elemento.valorTotalRecebido;
                aux = aux.prox;
            }

            // QuickSort
            Console.WriteLine($"Valor total gasto nas consultas: {valorTotal}");
        }

    }
}
