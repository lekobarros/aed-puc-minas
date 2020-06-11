using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_CLIN_MED
{
    class HashMedicos
    {
        ListaMedico[] VetMedicos;

        public HashMedicos()
        {
            VetMedicos = new ListaMedico[10];
            for (int i = 0; i < VetMedicos.Length; i++)
            {
                VetMedicos[i] = new ListaMedico();
            }
        }

        public bool Adicionar(Medico novo)
        {
            try
            {
                int especialista = novo.codEspecialidade;
                VetMedicos[especialista].Inserir(novo);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void AdicionarConsultaMedico(Consulta consulta)
        {
            var Medico = VetMedicos[consulta.codEspecialidade].RemoverPrimeiro();
            Medico.AdicionarAtendimento(consulta.tipo);
            VetMedicos[consulta.codEspecialidade].Inserir(Medico);
        }

        public int contarMedicos()
        {
            int soma = 0;
            for (int i = 0; i < VetMedicos.Length; i++)
            {
                soma += VetMedicos[i].contarMedicos();
            }
            return soma;
        }

        public void imprimirListaDeMedicos()
        {
            // cotnar os medicos
            // passar o vetor 
            // ordernar e imprimir 


            int contMed = this.contarMedicos();
            int totalPago = 0;
            Medico[] todosMedicos = new Medico[contMed];

            int indexMedico = 0;
            for (int j = 0; j < VetMedicos.Length; j++)
            {
                var localMed = VetMedicos[j].retornaLista();
                for (int k = 0; k < localMed.Length; k++, indexMedico++)
                {
                    todosMedicos[indexMedico] = localMed[k];
                }
            }
            
            // Ordenação
            QuickSort.Sort(todosMedicos);

            // Ordenar o Vetor
            for (int i = todosMedicos.Length - 1; i >= 0; i--)
            {
                Console.WriteLine($"Medico: {todosMedicos[i].nome} - Valor: {todosMedicos[i].valorTotalRecebido.ToString("c")}");
                totalPago += todosMedicos[i].valorTotalRecebido;
            }
            // Mostrar total pago
            Console.WriteLine($"Total Valor recebido: {totalPago.ToString("c")}");
        }
    }
}
