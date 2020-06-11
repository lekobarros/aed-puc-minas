using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_CLIN_MED
{
    class Paciente : IDado
    {
        public String cpf;
        public String nome;
        public Lista consultas;

        public Paciente(String cpf, String nome)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.consultas = new Lista();
        }

        public int comparar(string chaveDado)
        {
            return this.cpf.CompareTo(chaveDado);
        }

        public string nomeDado()
        {
            return $"Paciente: {this.nome}; CPF: {this.cpf}";
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
