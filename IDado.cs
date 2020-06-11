using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_CLIN_MED
{
    public interface IDado
    {
        //1 -> item é menor, 0 Igual, 1 maior -> s!
        int comparar(String chaveDado);
        // comparar_ tem que dar um return dizendo se a areia g q recebeu maior ou menor q sua chave
        IDado retornar();
        //return this
        String nomeDado();

        String retornaChaveDado();
        //tem que retorna s ref AccessViolationException     
    }
}