using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int gridSize = getNumber(3, 9);

            int[,] grid = generateGrid(gridSize);

            displayGrid(gridSize);

            bool running = true;

            while (running)
            {
                displayMenu();

                int menuItem = getNumber(1, 5);

                switch (menuItem)
                {
                    case 1:
                        displayHorizontalFlip(gridSize);
                        break;
                    case 2:
                        displayVerticalFlip(gridSize);
                        break;
                    case 3:
                        displayLDiagFlip(gridSize);
                        break;
                    case 4:
                        displayRDiagFlip(gridSize);
                        break;
                    case 5:
                        running = false;
                        break;
                    default:
                        break;

                }
            }



        }

        private static void displayRDiagFlip(int gridSize)
        {
            int[,] output = new int[5, 5];


            for (int i = 1; i <= gridSize; i++)
            {
                for (int j = 1; j <= gridSize; j++)
                {
                    output[j - 1, i - 1] = j * i;
                }
            }

            displayArray(output);
        }


        private static void displayLDiagFlip(int gridSize)
        {
            for (int i = gridSize; i > 0; i--)
            {
                for (int j = gridSize; j > 0; j--)
                {
                    Console.Write(i * j + " ");
                }
                Console.WriteLine();
            }
        }

        private static void displayVerticalFlip(int gridSize)
        {
            for (int i = 1; i <= gridSize; i++)
            {
                for (int j = gridSize; j > 0; j--)
                {
                    Console.Write(i * j + " ");
                }
                Console.WriteLine();
            }
        }

        private static void displayHorizontalFlip(int gridSize)
        {
            for (int i = gridSize; i > 0; i--)
            {
                for (int j = 1; j <= gridSize; j++)
                {
                    Console.Write(i * j + " ");
                }
                Console.WriteLine();
            }
        }

        static void displayMenu()
        {
            Console.WriteLine($"Choose an Option: \n" +
                $"1: Flip Horizontally\n" +
                $"2: Flip Vertically\n" +
                $"3: Diaganol Left\n" +
                $"4: Diaganol Right\n" +
                $"5: Exit\n");
        }

        static void displayGrid(int gridSize)
        {
            for (int i = 1; i <= gridSize; i++)
            {
                for (int j = 1; j <= gridSize; j++)
                {
                    Console.Write(i * j + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] generateGrid(int gridSize)
        {
            int[,] returnArray = new int[gridSize, gridSize];

            for (int i = 1; i <= gridSize; i++)
            {
                for (int j = 1; j <= gridSize; j++)
                {
                    returnArray[(i - 1), (j - 1)] = i * j;
                }
            }

            return returnArray;
        }

        static void displayArray(int[,] userArray)
        {
            for (int i = 0; i <= userArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= userArray.GetUpperBound(1); j++)
                {
                    Console.Write(userArray[i, j] + " ");
                }
                Console.WriteLine();
            }
        }



        static int getNumber(int lowerBound, int upperBound)
        {
            bool validNumber = false;
            int returnNumber = -1;
            while (!validNumber)
            {
                Console.Write($"Enter a number between {lowerBound} and {upperBound}: ");
                String userResponse = Console.ReadLine();
                int userNumber;
                bool isANumber = int.TryParse(userResponse, out userNumber);
                if (isANumber && userNumber >= lowerBound && userNumber <= upperBound)
                {
                    returnNumber = userNumber;
                    validNumber = true;
                }
                else
                {
                    Console.WriteLine("Invalid Number");
                }
            }
            return returnNumber;
        }
    }
}
