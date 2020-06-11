using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AED_CLIN_MED
{
    class TabelaHash
    {
        // refs: http://www.macoratti.net/10/05/c_arrays.htm
        public Arvore[,,] tabelaConsultas;
        private int anoReferencia;

        public TabelaHash()
        {
            Arvore[,,] matriz = new Arvore[22, 12, 31]; // YY MM DD
            tabelaConsultas = matriz;
            anoReferencia = 1999;
        }
        public void inserir(Consulta novoNodo)
        {
            int mes = novoNodo.dataConsulta.Month - 1;
            int dia = novoNodo.dataConsulta.Day - 1;
            int ano = novoNodo.dataConsulta.Year - anoReferencia;
            // Console.WriteLine("{0}, {1}, {2}", ano, mes, dia);
            if (tabelaConsultas[ano, mes, dia] == null)
            {
                tabelaConsultas[ano, mes, dia] = new Arvore();
            }

            tabelaConsultas[ano, mes, dia].inserir(novoNodo);
        }

        public Arvore pesquisaTodasConsultasData(DateTime element)
        {

            int mes = element.Month - 1;
            int dia = element.Day - 1;
            int ano = element.Year - anoReferencia;

            // se a posição na matriz não está vazia, retorna a árvore de consulta.
            if (tabelaConsultas[ano, mes, dia] != null)
            {
                return tabelaConsultas[ano, mes, dia];
            }
            else
            {
                return null;
            }
        }
        public void pesquisaTodasConsultasDataEspecialidade(DateTime element, int codEspecialidade)
        {
            var ConsultasData = pesquisaTodasConsultasData(element);
            if (ConsultasData != null) {
                ConsultasData.InOrdem(codEspecialidade);
            }
            else
            {
                Console.WriteLine("Não existe nenhuma consulta nesta data");
            }

        }
        public void imprimirData(Arvore Arvore)
        {
            Arvore.percorre(2);
        }
        public Consulta pesquisaConsultaEspecifica(DateTime data, String cpf)
        {
            int mes = data.Month - 1;
            int dia = data.Day - 1;
            int ano = data.Year - anoReferencia;

            if (tabelaConsultas[ano, mes, dia] != null)
            {
                return (Consulta)tabelaConsultas[ano, mes, dia].procurar(cpf);

            }
            else return null;
        }
        public bool remover(Consulta nodo)//remove uma consulta 
        {

            int mes = nodo.dataConsulta.Month - 1;
            int dia = nodo.dataConsulta.Day - 1;
            int ano = nodo.dataConsulta.Year - anoReferencia;

            if (tabelaConsultas[ano, mes, dia] != null)
            {
                return tabelaConsultas[ano, mes, dia].remover(nodo.cpf);
            }

            return false;


        }
    }

    public static class MyExtensions
    {
        public static void InOrdem(this Arvore arvore, int codEspecialidade)
        {
            string Saida = "";
            InOrdem(arvore, codEspecialidade, arvore.raiz, ref Saida);
            if(Saida.Length == 0)
                Console.WriteLine("Para essa não tem registro de consulta com essa especialidade!");
            else
                Console.WriteLine(Saida);
        }

        private static void InOrdem(this Arvore arvore, int codEspecialidade, Nodo raiz,ref string saida)
        {
            if (raiz != null)
            {
                InOrdem(arvore, codEspecialidade, raiz.filhoEsquerdo, ref saida);
                if(((Consulta)raiz.elemento.retornar()).codEspecialidade == codEspecialidade )
                   saida += raiz.elemento.nomeDado() + " \n";
                InOrdem(arvore, codEspecialidade, raiz.filhoDireito, ref saida);
            }
        }


    }
}

