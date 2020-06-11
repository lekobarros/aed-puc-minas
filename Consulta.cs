using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_CLIN_MED
{
    class Consulta: IDado
    {
        public String cpf;
        public int tipo;
        public int codEspecialidade;
        public DateTime dataConsulta;
        public Consulta prox;
        public double ValorConsulta;
  
        public Consulta (String cpf, int tipo, int cod, DateTime data)
        {
            this.cpf = cpf;
            this.tipo = tipo;
            this.codEspecialidade = cod;
            this.dataConsulta = data;
            this.ValorConsulta = tipo == 0 ? ValoresConsultas.valorConsultaAgendada : ValoresConsultas.valorConsultaDemanda;
        }

        public int comparar(string chaveDado)
        {
            return this.cpf.CompareTo(chaveDado);
        }

        public string nomeDado()
        {
            return $"Consulta: {this.cpf}; Tipo: {this.tipo}; Cód. Especialidade: {this.codEspecialidade}; Data de Consulta: {this.dataConsulta}";
        }

        public string retornaChaveDado()
        {
            return this.cpf;
        }

        public IDado retornar()
        {
            return this;
        }
    }
}
