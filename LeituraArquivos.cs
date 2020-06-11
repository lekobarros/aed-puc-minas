using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

// Try
namespace AED_CLIN_MED
{
    class LeituraArquivos
    {
        string line = "";

        public void LerPacientes(String arq, Arvore ArvPaciente)
        {
            Console.WriteLine("Iniciando leitura dos paciêntes...");
            var sw = new Stopwatch();
            sw.Start();
            System.IO.StreamReader file = new System.IO.StreamReader(arq);
            while ((line = file.ReadLine()) != null)
            {
                string[] DadosColetados = line.Split(';');
                var cpf = DadosColetados[0];
                var nome = DadosColetados[1];
                Paciente paciente = new Paciente(cpf, nome);
                ArvPaciente.inserir(paciente);
            }
            sw.Stop();
            file.Close();
            Console.WriteLine("Total de tempo de leitura do Paciênte : " + sw.ElapsedMilliseconds.ToString() + " milisegundos");
        }

        public void LerMedico(String arq, HashMedicos tabelaMedico)
        {
            Console.WriteLine("Iniciando leitura dos médicos...");
            var sw = new Stopwatch();
            sw.Start();
            System.IO.StreamReader file = new System.IO.StreamReader(arq);
            while ((line = file.ReadLine()) != null)
            {
                string[] DadosColetados = line.Split(';');
                var crm = DadosColetados[0];
                var nome = DadosColetados[1];
                var codEspecialidade = int.Parse(DadosColetados[2]);

                Medico medico = new Medico(crm, nome, codEspecialidade);
                tabelaMedico.Adicionar(medico);

            }
            sw.Stop();
            file.Close();
            Console.WriteLine("Total de tempo de leitura do médicos : " + sw.ElapsedMilliseconds.ToString() + " milisegundos");
            // Suspend the screen.  
        }

        public void LerConsultas(String arq, TabelaHash Hash, Arvore ArvPaciente, HashMedicos tabelaMedicos)
        {
            Console.WriteLine("Iniciando leitura das consultas...");
            var sw = new Stopwatch();
            sw.Start();
            System.IO.StreamReader file = new System.IO.StreamReader(arq);
            while ((line = file.ReadLine()) != null)
            {
                string[] DadosColetados = line.Split(';');
                var cpf = DadosColetados[0];
                var tipo = int.Parse(DadosColetados[1]);
                var especialidade = int.Parse(DadosColetados[2]);
                var data = Convert.ToDateTime(DadosColetados[3]);

                Consulta consulta = new Consulta(cpf, tipo, especialidade, data);
                Hash.inserir(consulta);
                
                tabelaMedicos.AdicionarConsultaMedico(consulta);

                // buscar o cpf e inserir na lista a consulta do cliente
                ((Paciente)ArvPaciente.procurar(cpf)).consultas.adicionar(consulta);
            }
            sw.Stop();
            file.Close();
            Console.WriteLine("Tempo gasto : " + sw.ElapsedMilliseconds.ToString() + " milisegundos");
        }
        public void Exibir(string[] vetor)
        {
            for (int i = 0; i < vetor.Length; i++)
            {
                Console.WriteLine(vetor[0] + " " + vetor[1]);
            }
        }

    }
}
