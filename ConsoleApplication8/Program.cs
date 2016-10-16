using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter size:");
            int size = Convert.ToInt32(Console.ReadLine());

            int bombCount = InputBombCount(size);

            Cell[,] array = CreateArray(size);

            ArrangeBombs(array, bombCount);
            CountBombs(array);

            Console.WriteLine("The game started");
            PrintArray(array, false);

            bool gameContinue = true;
            int openCellCount = 0;
            while (gameContinue)
            {

                Cell cell = InputCell(array);
                openCellCount++;
                PrintArray(array, false);

                if (cell.Value != 9)
                {
                    gameContinue = !IsWin(openCellCount, size, bombCount);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Game over");
                    Console.WriteLine();
                    Console.WriteLine("Bombs located:");

                    PrintArray(array, true);
                    gameContinue = false;
                }
            }
            Console.ReadLine();
        }

        public static bool IsWin(int openCellCount, int size, int bombCount)
        {
            if (openCellCount == size * size - bombCount)
            {
                Console.WriteLine("You win!!!");
                return true;
            }

            return false;
        }

        private static int InputBombCount(int size)
        {
            int bombCount;
            bool normalBombCount = false;

            do
            {
                Console.WriteLine("Enter count of bombs:");
                bombCount = Convert.ToInt32(Console.ReadLine());
                normalBombCount = bombCount <= size * size;
                if (!normalBombCount)
                {
                    Console.WriteLine("Quantity of bombs over the field size");
                }

            }
            while (!normalBombCount);
            return bombCount;
        }

        public static void ArrangeBombs(Cell[,] array, int bombCount)
        {
            Random random = new Random();

            for (int k = 0; k < bombCount; k++)
            {
                int l = random.Next(array.GetLength(0));
                int m = random.Next(array.GetLength(1));
                if (array[l, m].Value != 9)
                {
                    array[l, m].Value = 9;
                }
                else
                {
                    k--;
                }
            }

        }
        public static void CountBombs(Cell[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    int count = 0;
                    if (array[i, j].Value != 9)
                    {

                        if (i >= 0 && i < array.GetLength(0) && j - 1 >= 0 && j - 1 < array.GetLength(1))
                        {

                            if (array[i, j - 1].Value == 9)
                            {
                                count++;
                            }
                        }
                        if (i - 1 >= 0 && i - 1 < array.GetLength(0) && j - 1 >= 0 && j - 1 < array.GetLength(1))
                        {

                            if (array[i - 1, j - 1].Value == 9)
                            {
                                count++;
                            }
                        }
                        if (i - 1 >= 0 && i - 1 < array.GetLength(0) && j >= 0 && j < array.GetLength(1))
                        {
                            if (array[i - 1, j].Value == 9)
                            {

                                count++;
                            }
                        }
                        if (i - 1 >= 0 && i - 1 < array.GetLength(0) && j + 1 >= 0 && j + 1 < array.GetLength(1))
                        {
                            if (array[i - 1, j + 1].Value == 9)
                            {

                                count++;
                            }
                        }
                        if (i >= 0 && i < array.GetLength(0) && j + 1 >= 0 && j + 1 < array.GetLength(1))
                        {
                            if (array[i, j + 1].Value == 9)
                            {

                                count++;
                            }
                        }
                        if (i + 1 >= 0 && i + 1 < array.GetLength(0) && j + 1 >= 0 && j + 1 < array.GetLength(1))
                        {
                            if (array[i + 1, j + 1].Value == 9)
                            {

                                count++;
                            }
                        }
                        if (i + 1 >= 0 && i + 1 < array.GetLength(0) && j >= 0 && j < array.GetLength(1))
                        {
                            if (array[i + 1, j].Value == 9)
                            {

                                count++;
                            }
                        }
                        if (i + 1 >= 0 && i + 1 < array.GetLength(0) && j - 1 >= 0 && j - 1 < array.GetLength(1))
                        {
                            if (array[i + 1, j - 1].Value == 9)
                            {

                                count++;
                            }
                        }

                        array[i, j].Value = count;
                    }
                }


            }
        }


        public static Cell[,] CreateArray(int size)
        {
            Cell[,] array = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = new Cell();

                }
            }
            return array;
        }

        public static Cell InputCell(Cell[,] array)
        {
            Console.WriteLine("Enter indexes:");

            int i = Convert.ToInt32(Console.ReadLine());
            int j = Convert.ToInt32(Console.ReadLine());

            if (i >= array.Length || j >= array.Length || i < 0 || j < 0)
            {
                Console.WriteLine("Wrong indexes");
            }
            else
            {
                array[i, j].IsOpen = true;
            }

            return array[i, j];

        }


        public static void PrintArray(Cell[,] array, bool showBombs)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j].IsOpen)
                    {
                        if (array[i, j].Value == 9)
                        {
                            Console.Write(" " + '@' + " ");
                        }
                        else
                        {
                            Console.Write(" " + array[i, j].Value + " ");
                        }
                    }
                    else
                    {
                        if (showBombs && array[i, j].Value == 9)
                        {
                            Console.Write(" " + '@' + " ");
                        }
                        else
                        {
                            Console.Write(" " + '*' + " ");
                        }
                    }

                }
                Console.WriteLine();
            }

        }


    }
}











