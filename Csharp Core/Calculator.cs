using System;

namespace C__Calculator
{
    internal class Calculator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------ CALCULATOR ------");
            Console.WriteLine("1. Addition\n2. Subtraction\n3. Multiplication\n4. Division\n5. Exit\n");
            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("select an operation: ");
                int op = int.Parse(Console.ReadLine()); ;
                switch (op)
                {
                    case 1: Console.WriteLine(Addition()); break;
                    case 2: Console.WriteLine(Subtraction()); break;
                    case 3: Console.WriteLine(Multiplication()); break;
                    case 4: Console.WriteLine(Division()); break;
                    case 5: Console.WriteLine("Exiting ..."); isRunning = false; break;
                    default: Console.WriteLine("Please enter a valid operation!"); break;
                }
            }
        }
  

        public static int Addition()
        {
            Console.Write("Include First number: "); 
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Include Second number: "); 
            int num2 = int.Parse(Console.ReadLine());
             
            return num1 + num2;
        }

        public static int Subtraction()
        {
            Console.Write("Include First number: "); 
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Include Second number: "); 
            int num2 = int.Parse(Console.ReadLine());
             
            return num1 - num2;
        }

        public static int Multiplication()
        {
            Console.Write("Include First number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Include Second number: ");
            int num2 = int.Parse(Console.ReadLine());

            return num1 * num2;
        }

        public static int Division()
        {
            Console.Write("Include First number: "); 
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Include Second number: "); 
            int num2 = int.Parse(Console.ReadLine());
            
            if (num2 != 0)
            {
                return num1 / num2;
            }
            else
            {
                Console.WriteLine("Error! Division by zero is not allowed!");
                return 0;
            }
        }
    }
}
