using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_CLIN_MED
{
    public class Medico
    {
        public String crm;
        public String nome;
        public int codEspecialidade;
        public int atendimentoAgendado;
        public int atendimentoDemanda;
        public int valorTotalRecebido;

        public Medico (String crm, String nome, int cod)
        {
            this.crm = crm;
            this.nome = nome;
            this.codEspecialidade = cod;
            this.atendimentoAgendado = 0;
            this.atendimentoDemanda = 0;
        }

        public int comparar(string chaveDado)
        { 
            return this.crm.CompareTo(chaveDado);
        }
   
        public string nomeDado()
        {
            return $"Médico: {this.nome}; CRM: {this.crm}; Cód. Especialidade: {this.codEspecialidade}";
        }

        public string retornaChaveDado()
        {
            return this.crm;
        }

        public void AdicionarAtendimento(int tipoAtendimento)
        {
            if (tipoAtendimento == 0)
                atendimentoAgendado++;
            else
                atendimentoDemanda++;

            var valorDaConsulta = tipoAtendimento == 0 ? ValoresConsultas.valorConsultaAgendada : ValoresConsultas.valorConsultaDemanda;
            valorTotalRecebido += valorDaConsulta;
        }

     


    }
}
