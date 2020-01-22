using System;
using System.Collections;
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
            bool running = true;

            while (running)
            {
                Console.WriteLine("1: Grid Example\n2: Class Example\n3: Exit");

                int program = getNumber(1, 3);

                switch (program)
                {
                    case 1:
                        doGridExample();
                        break;
                    case 2:
                        doPersonExample();
                        break;
                    case 3:
                        running = false;
                        break;
                    default:
                        break;
                }
            }



        }

        private static void doPersonExample()
        {
            bool exRunning = true;

            ArrayList people = new ArrayList();

            while(exRunning)
            {
                Console.WriteLine($"1: Add Student\n 2: Add Teacher\n3: Exit");
                int choice = getNumber(1, 3);
                switch(choice)
                {
                    case 1:
                        people.Add(addStudent());
                        break;
                    case 2:
                        people.Add(addTeacher());
                        break;
                    case 3:
                        exRunning = false;
                        displayPeople(people);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void displayPeople(ArrayList people)
        {
            foreach(Person p in people)
            {
                Console.WriteLine("\n" + p.ToString() + "\n");
            }
        }

        private static Teacher addTeacher()
        {
            Teacher teacher = new Teacher();
            Console.Write("Name: ");
            teacher.name = Console.ReadLine();

            bool validAge = false;
            while (!validAge)
            {
                Console.Write("Age: ");
                string userNumStr = Console.ReadLine();
                int userNum;
                bool isNumber = int.TryParse(userNumStr, out userNum);
                if (isNumber && userNum >= 0)
                {
                    validAge = true;
                    teacher.age = userNum;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            Console.WriteLine("ID: ");
            teacher.ID = Console.ReadLine();

            Console.WriteLine("Program: \n" +
                "1: Computer Science\n" +
                "2: Accounting\n" +
                "3: Marketing\n" +
                "4: Nursing\n");
            int program = getNumber(1, 4);
            switch (program)
            {
                case 1:
                    teacher.schoolProgram = SchoolProgram.Computer_Science;
                    break;
                case 2:
                    teacher.schoolProgram = SchoolProgram.Accounting;
                    break;
                case 3:
                    teacher.schoolProgram = SchoolProgram.Marketing;
                    break;
                case 4:
                    teacher.schoolProgram = SchoolProgram.Nursing;
                    break;
                default:
                    break;
            }

            bool validYr = false;
            while (!validYr)
            {
                Console.Write("Years of Service: ");
                string userNumStr = Console.ReadLine();
                int userNum;
                bool isNumber = int.TryParse(userNumStr, out userNum);
                if (isNumber && userNum >= 0)
                {
                    validYr = true;
                    teacher.yearsOfService = userNum;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            return teacher;
        }

        private static Student addStudent()
        {
            Student student = new Student();
            Console.Write("Name: ");
            student.name = Console.ReadLine();

            bool validAge = false;
            while(!validAge)
            {
                Console.Write("Age: ");
                string userNumStr = Console.ReadLine();
                int userNum;
                bool isNumber = int.TryParse(userNumStr, out userNum);
                if(isNumber && userNum >= 0)
                {
                    validAge = true;
                    student.age = userNum;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            Console.WriteLine("ID: ");
            student.ID = Console.ReadLine();

            Console.WriteLine("Program: \n" +
                "1: Computer Science\n" +
                "2: Accounting\n" +
                "3: Marketing\n" +
                "4: Nursing\n");
            int program = getNumber(1,4);
            switch(program)
            {
                case 1:
                    student.schoolProgram = SchoolProgram.Computer_Science;
                    break;
                case 2:
                    student.schoolProgram = SchoolProgram.Accounting;
                    break;
                case 3:
                    student.schoolProgram = SchoolProgram.Marketing;
                    break;
                case 4:
                    student.schoolProgram = SchoolProgram.Nursing;
                    break;
                default:
                    break;
            }

            bool validCr = false;
            while (!validCr)
            {
                Console.Write("Credits Earned: ");
                string userNumStr = Console.ReadLine();
                int userNum;
                bool isNumber = int.TryParse(userNumStr, out userNum);
                if (isNumber && userNum >= 0)
                {
                    validCr = true;
                    student.creditsEarned = userNum;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            return student;

        }

        public enum SchoolProgram
        {
            Computer_Science,
            Accounting,
            Marketing,
            Nursing
        }

        public class Person
        {
            public string name { get; set; }
            public string ID { get; set; }
            public int age { get; set; }
            public SchoolProgram schoolProgram { get; set; }

            public virtual string ToString()
            {
                return $"Name: {name}\nID: {ID}\nAge: {age}\nProgram: {schoolProgram}";
            }
        }

        public class Teacher:Person
        {
            public int yearsOfService { get; set; }

            public override string ToString()
            {
                return base.ToString() + $"\nYears of Service: {yearsOfService}";
            }
        }

        public class Student : Person
        {
            public int creditsEarned { get; set; }

            public override string ToString()
            {
                return base.ToString() + $"\nCredits Earned: {creditsEarned}";
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

        private static void doGridExample()
        {
            int gridSize = getNumber(3, 9);

            int[,] grid = generateGrid(gridSize);

            displayGrid(gridSize);

            bool exRunning = true;

            while (exRunning)
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
                        exRunning = false;
                        break;
                    default:
                        break;

                }
            }
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
