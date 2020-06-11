using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_CLIN_MED
{
    class Lista
    {
        Consulta primeiro;
        Consulta ultimo;

        public Lista()
        {
            primeiro = new Consulta("", 0, 0, Convert.ToDateTime("01/01/2000"));
            ultimo = primeiro;
        }

        // metodo que insere no final da lista
        public Consulta adicionar(Consulta novo)
        {
            ultimo.prox = novo;
            ultimo = novo;
            return ultimo;
        }
  
        // metodo de retirada da lista
        public Consulta eliminar(String cpf)
        {
            Consulta aux, anterior;
            aux = primeiro.prox;
            anterior = primeiro;

            while (aux != null)
            {
                if (aux.cpf == cpf)
                {
                    anterior.prox = aux.prox;

                    if (aux == ultimo)
                    {
                        ultimo = anterior;
                    }
                    return aux;
                }
                else { anterior = aux; aux = aux.prox; }
            }
            return aux;
        }



        public void imprime()
        {
            Consulta aux = primeiro.prox;
            double valor = 0;
            while (aux != null)
            {
                Console.WriteLine($"Data da Consulta: {aux.dataConsulta}, CodEspecialidade: {aux.codEspecialidade}, Consulta do tipo:" + (aux.tipo == 0 ? "Agendada" : "Sobre demanda") + $" Valor da Consulta: {aux.ValorConsulta.ToString("c")}");
                valor = valor + aux.ValorConsulta;
                aux = aux.prox;
            }
            Console.WriteLine($"Valor total gasto nas consultas: {valor.ToString("c")}");
        }
    }
}
