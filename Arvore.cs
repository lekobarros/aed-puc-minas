using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AED_CLIN_MED
{
    public class Arvore
    {
        public Nodo raiz; // primeiro nodo da arvore

        public Arvore() // construtor
        {
            raiz = null; // ainda nao existem nodos na arvore
        }

        public void inserir(IDado Novo)

        {
            Nodo novoNodo = new Nodo(); // cria um novo nodo
            novoNodo.elemento = Novo; //

            if (raiz == null) // nao existe nodo na raiz
                raiz = novoNodo;
            else // raiz ocupada
            {
                Nodo corrente = raiz; // inicia como raiz

                while (true) // (existe internamente - ja criado)
                {

                    if (corrente.elemento.comparar(novoNodo.elemento.retornaChaveDado()) == 1) // vai para esquerda?
                    {

                        if (corrente.filhoEsquerdo == null) // se for o fim da linha
                        {
                            corrente.filhoEsquerdo = novoNodo; // insere a esquerda
                            return;
                        }
                        else
                        {
                            corrente = corrente.filhoEsquerdo;
                        }
                    } // fim da insersao a esquerda
                    else // ou vai para a direita?
                    {

                        if (corrente.filhoDireito == null) // se for o fim da linha
                        {
                            corrente.filhoDireito = novoNodo; // insere a direita
                            return;

                        }
                        else
                        {
                            corrente = corrente.filhoDireito;
                        }

                    } // fim da insersao a direita
                } // fim while
            } // fim else nao e raiz
        } // fim insere()

        public void percorre(int tipoPercorrimento)
        {
            switch (tipoPercorrimento)
            {
                case 1:
                    Console.WriteLine("\n\t\t\tPercorre em Pre_Ordem: ");
                    Console.WriteLine("\t\t\t");
                    preOrdem(raiz);
                    break;
                case 2:
                    Console.WriteLine("\n\t\t\tPercorre em In_Ordem : ");
                    Console.WriteLine("\t\t\t");
                    inOrdem(raiz);
                    break;
                case 3:
                    Console.WriteLine("\n\t\t\tPercorre em PosOrdem : ");
                    Console.WriteLine("\t\t\t");
                    posOrdem(raiz);
                    break;

            }
            Console.WriteLine();
        }

        private void preOrdem(Nodo localRaiz)
        {
            if (localRaiz != null)
            {
                Console.WriteLine(localRaiz.elemento.nomeDado() + " ");
                preOrdem(localRaiz.filhoEsquerdo);
                preOrdem(localRaiz.filhoDireito);
            }
        }

        private void inOrdem(Nodo localRaiz)
        {
            if (localRaiz != null)
            {
                inOrdem(localRaiz.filhoEsquerdo);
                Console.WriteLine(localRaiz.elemento.nomeDado() + " ");
                inOrdem(localRaiz.filhoDireito);
            }
        }

        private void posOrdem(Nodo localRaiz)
        { // fofo
            if (localRaiz != null)
            {
                posOrdem(localRaiz.filhoEsquerdo);
                posOrdem(localRaiz.filhoDireito);
                Console.WriteLine(localRaiz.elemento.nomeDado() + " ");
            }
        }

        public Boolean remover(String Chave)
        {
            Nodo Corrente = raiz;

            while (Corrente != null)
            {
                if (Corrente.elemento.comparar(Chave) == 0)
                {
                    Nodo auxiliar = elementoSubstituto(Corrente);
                    if (auxiliar == null)
                    {
                        Corrente = null;
                        return true;
                    }
                    else
                    {
                        auxiliar.filhoDireito = Corrente.filhoDireito;
                        auxiliar.filhoEsquerdo = Corrente.filhoEsquerdo;
                        Corrente = auxiliar;
                        return true;
                    }

                }
                else
                {
                    if (Corrente.elemento.comparar(Chave) == 1)
                    {
                        Corrente = Corrente.filhoEsquerdo;
                    }
                    else
                    {
                        Corrente = Corrente.filhoDireito;
                    }
                }
                return false;
            }

            return false;

        }

        private Nodo elementoSubstituto(Nodo corrente)

        {
            if (corrente.filhoDireito == null && corrente.filhoEsquerdo == null)
            {
                return null;
            }
            if (corrente.filhoDireito != null && corrente.filhoEsquerdo == null)
            {
                return corrente.filhoDireito;
            }
            if (corrente.filhoEsquerdo != null && corrente.filhoDireito == null)
            {
                return corrente.filhoEsquerdo;
            }
            else
            {
                Nodo auxiliar = corrente.filhoEsquerdo;
                Nodo auxiliar2 = auxiliar;
                while (auxiliar.filhoDireito != null)
                {
                    auxiliar2 = auxiliar;

                    auxiliar = auxiliar.filhoDireito;

                }
                auxiliar2.filhoDireito = auxiliar.filhoEsquerdo;
                auxiliar.filhoEsquerdo = null;
                return auxiliar;

            }

        }

        public IDado procurar(String chave)
        {
            var sw = new Stopwatch();
            sw.Start();
            Nodo Corrente = raiz;

            while (Corrente != null)
            {
                if (Corrente.elemento.comparar(chave) == 0)
                {
                    sw.Stop();
                    return Corrente.elemento;
                }

                if (Corrente.elemento.comparar(chave) == -1)
                {

                    Corrente = Corrente.filhoDireito;

                }
                else
                {
                    Corrente = Corrente.filhoEsquerdo;
                }
            }
            sw.Stop();
            return null;

        }

    }
}

