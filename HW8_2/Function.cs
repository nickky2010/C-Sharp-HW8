using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_2
{
    class Function
    {
        public static void ShowMatrix (int [,] matrix, Func<int, bool> criterion, Action<string> action)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (criterion(matrix[i, j]))
                    {
                        action(matrix[i, j].ToString());
                        action("  ");
                    }
                }
                action("\n");
            }
        }
    }
}
