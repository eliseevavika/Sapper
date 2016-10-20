using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Opener
    {
        public static void Open(Cell[,] array, int i, int j)
        {
            array[i, j ].IsOpen = true;

            if (array[i, j].Value == 0)
            {
                if (i >= 0 && i < array.GetLength(0) && j - 1 >= 0 && j - 1 < array.GetLength(1))
                {
                    if(!array[i, j - 1].IsOpen)
                    {
                        Open(array,i,j-1);
                    }
                    

                }
                if (i - 1 >= 0 && i - 1 < array.GetLength(0) && j - 1 >= 0 && j - 1 < array.GetLength(1))
                {

                    if (!array[i-1, j - 1].IsOpen)
                    {
                        Open(array, i-1, j-1);
                    }
                }
                if (i - 1 >= 0 && i - 1 < array.GetLength(0) && j >= 0 && j < array.GetLength(1))
                {
                    if (!array[i - 1, j ].IsOpen)
                    {
                        Open(array, i - 1, j );
                    }
                }
                if (i - 1 >= 0 && i - 1 < array.GetLength(0) && j + 1 >= 0 && j + 1 < array.GetLength(1))
                {
                    if (!array[i - 1, j + 1].IsOpen)
                    {
                        Open(array, i - 1, j + 1);
                    }
                }
                if (i >= 0 && i < array.GetLength(0) && j + 1 >= 0 && j + 1 < array.GetLength(1))
                {
                    if (!array[i, j +1].IsOpen)
                    {
                        Open(array, i , j + 1);
                    }
                }
                if (i + 1 >= 0 && i + 1 < array.GetLength(0) && j + 1 >= 0 && j + 1 < array.GetLength(1))
                {
                    if (!array[i + 1, j + 1].IsOpen)
                    {
                        Open(array, i + 1, j + 1);
                    }
                }
                if (i + 1 >= 0 && i + 1 < array.GetLength(0) && j >= 0 && j < array.GetLength(1))
                {
                    if (!array[i + 1, j ].IsOpen)
                    {
                        Open(array, i + 1, j );
                    }
                }
                if (i + 1 >= 0 && i + 1 < array.GetLength(0) && j - 1 >= 0 && j - 1 < array.GetLength(1))
                {
                    if (!array[i + 1, j - 1].IsOpen)
                    {
                        Open(array, i + 1, j - 1);
                    }
                }


            }
        }
    }
}



