using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace AED_CLIN_MED
{
    class Program
    {
        static int obterMenu()
        {
            // Console.Clear();
            Console.WriteLine("1 - Mostrar, para um paciente, todas as suas consultas e o valor total pago.");
            Console.WriteLine("2 - Exibir, em uma data, todas as consultas de uma especialidade.");
            Console.WriteLine("3 - Exibir um relatório, em ordem decrescente de valores, dos médicos e valor es recebidos.");
            Console.WriteLine("4 - Limpar o console");
            Console.WriteLine("5 - Sair do programa");
            Console.Write("Informe uma das opções listadas acima: ");

            // try catch here ?
            int opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        static void Main(string[] args)
        {
            // Estrutura de Dados
            Arvore ArvPaciente = new Arvore();
            TabelaHash HashConsultas = new TabelaHash();
            HashMedicos tabelaMedicos = new HashMedicos();

            // Controle da Aplicação
            Boolean arquivoCarregado = false;
            int state = 0;

            // Do while para controlar as opções do programa
            do
            {
                // Na primeira execução faz a leitura dos arquivos no caminho informado
                if (!arquivoCarregado)
                {
                    try
                    {
                        // Caminho dos arquivos p/ leitura
                        String arqMedicos = @"D:\PUC\AED\dadosMedicos.txt";
                        String arqPacientes = @"D:\PUC\AED\dadosPacientes.txt";
                        String artConsultas = @"D:\PUC\AED\dadosCons.txt";

                        // Leituras
                        LeituraArquivos Leitura = new LeituraArquivos();
                        Leitura.LerPacientes(arqPacientes, ArvPaciente);
                        Leitura.LerMedico(arqMedicos, tabelaMedicos);
                        Leitura.LerConsultas(artConsultas, HashConsultas, ArvPaciente, tabelaMedicos);
                        Console.WriteLine("Leitura dos arquivos foi finalizado com sucesso.\n");
                        // Enable file read
                        arquivoCarregado = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro encontrado na leitura do arquivo:");
                        Console.WriteLine(e.Message);
                        // Encerra o programa
                        state = 4;
                        break;
                    }
                }

                // Controle de atividade da aplicação
                try
                {
                    state = obterMenu();
                } catch
                {
                    Console.WriteLine("Não foi possivel reconhecer a opção, tente novamente");
                }

                switch (state)
                {
                    case 1:
                        Console.WriteLine("Mostrar, para um paciente, todas as suas consultas e o valor total pago.");
                        Console.WriteLine("Informe o CPF do paciente no formato 000000000-00");
                        // Pegar o CPF
                        try
                        {
                            // GET CPF and Validate with regex
                            String cpf = Console.ReadLine();
                            String patternCpf = @"[0-9]{9}[-]?[0-9]{2}$";
                            var rgx = Regex.Match(cpf, patternCpf, RegexOptions.IgnoreCase);

                            if (rgx.Success)
                            {
                                var sw = new Stopwatch();
                                sw.Start();
                                Paciente pac = ((Paciente)ArvPaciente.procurar(cpf));
                                if (pac != null)
                                {
                                    pac.consultas.imprime();
                                } else
                                {
                                    Console.WriteLine("O CPF informado não consta na lista de pacientes!");
                                }
                                sw.Stop();
                                Console.WriteLine("Tempo gasto : " + sw.ElapsedMilliseconds.ToString() + " milisegundos");
                            }
                            else
                            {
                                Console.WriteLine("O formato do CPF informado é invalido. Tente novamente com o formato 000000000-00");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            Console.ReadKey();
                            break;
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        //Console.Clear();
                        // Obter data
                        try
                        {
                            Console.WriteLine("Exibir, em uma data, todas as consultas de uma especialidade.");
                            Console.WriteLine("Informe uma dana no formato DD/MM/YYYY:");
                            DateTime data = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Informe a identificação da especialdiade 0 a 9:");
                            int codEspecialidade = int.Parse(Console.ReadLine());

                            // Verificar como será esse retorno !
                            var sw = new Stopwatch();
                            sw.Start();
                            HashConsultas.pesquisaTodasConsultasDataEspecialidade(data, codEspecialidade);
                            sw.Stop();
                            Console.WriteLine("Tempo gasto : " + sw.ElapsedMilliseconds.ToString() + " milisegundos");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("O valor informado não é uma data válida ou não existe o código de especialidade, informe a õpção novamente.");
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                            break;
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        // Console.Clear();
                        Console.WriteLine("Exibir um relatório, em ordem decrescente de valores, dos médicos e valor es recebidos.");
                        // Relatorio
                        tabelaMedicos.imprimirListaDeMedicos();
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        break;
                }
            } while (state != 5);
            Console.ReadKey();
        }
    }
}