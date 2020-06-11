using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_CLIN_MED
{
    public class Nodo
    {
	    public IDado elemento;
        public Nodo filhoEsquerdo; // filho esquerdo
        public Nodo filhoDireito; // filho direito

        public void exibeNodo() // s,quer q tire?
        {
            Console.WriteLine('{');
            Console.WriteLine(elemento.nomeDado()); // <--saquei
            Console.WriteLine(", ");
            Console.WriteLine("} ");
        }
    }
}

