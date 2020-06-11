using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AED_CLIN_MED
{
    class QuickSort
    {
        static int Partition(Medico[] array, int low, int high)
        {
            // Seleciona o Pivô
            Medico pivot = array[high];

            int lowIndex = (low - 1);

            // Reordena
            for (int j = low; j < high; j++)
            {
                if (array[j].valorTotalRecebido <= pivot.valorTotalRecebido)
                {
                    lowIndex++;

                    Medico temp = array[lowIndex];
                    array[lowIndex] = array[j];
                    array[j] = temp;
                }
            }

            Medico temp1 = array[lowIndex + 1];
            array[lowIndex + 1] = array[high];
            array[high] = temp1;
            return lowIndex + 1;
        }


        static void Sort(Medico[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                // Recursividade ...
                Sort(array, low, partitionIndex - 1);
                Sort(array, partitionIndex + 1, high);
            }
        }


        public static void Sort(Medico[] array)
        {
            Sort(array, 0, array.Length - 1);
        }
    }
}
