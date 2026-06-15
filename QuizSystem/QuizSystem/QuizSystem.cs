using System;
using System.Linq;
using System.Threading;

namespace QuizSystem
{
    internal class QuizSystem
    {
        static void rateUs() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            short selected = 0;
            string[] star = { "🌟🌟🌟🌟🌟", "🌟🌟🌟🌟", "🌟🌟🌟", "🌟🌟", "🌟" };
            string ur_feedback= "";

            while (true)
            {
                Console.Clear(); 

                for (short k = 0; k < star.Length; k++)
                {
                    if (k == selected)
                    { 
                        Console.BackgroundColor = ConsoleColor.DarkGray;  
                        Console.WriteLine($">>  < {star[k]} >"); 
                        Console.ResetColor();  
                    }
                    else 
                        Console.WriteLine($"      {star[k]}  "); 
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && selected > 0)
                    selected--;

                if (key.Key == ConsoleKey.DownArrow && selected < star.Length - 1)
                    selected++;

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("Thank you for your feedback.\n");
                    break;
                }
            }
        }

        static void startQuiz()
        {
            short totalPoint = 0;
            string[] questions =
            {
    "\n1. What type is int?\n",
    "\n2. What type is string?\n",
    "\n3. Which method returns an object's hash code?\n",
    "\n4. Which property returns the length of an array?\n",
    "\n5. What does Console.ReadKey() do?\n",
    "\n6. What type is a class?\n",
    "\n7. What type is a struct?\n",
    "\n8. Which keyword is used to create an object?\n",
    "\n9. What does foreach do?\n",
    "\n10. What does var do in C#?\n",
    "\n11. What is the default value of a bool variable?\n",
    "\n12. At what index does an array start?\n",
    "\n13. What does break do?\n",
    "\n14. What does continue do?\n",
    "\n15. Which statement is used for exception handling?\n",
    "\n16. What is a constructor?\n",
    "\n17. What does null mean?\n",
    "\n18. Which collection can grow dynamically?\n",
    "\n19. What does ToString() do?\n",
    "\n20. What is the entry point of a C# application?\n"
};

            string[,] answers =
            {
    { "Reference Type", "Value Type", "Dynamic Type" },
    { "Reference Type", "Value Type", "Pointer Type" },
    { "Equals()", "GetHashCode()", "ToString()" },
    { "Size", "Count", "Length" },
    { "Reads a file", "Waits for a key press", "Clears the screen" },
    { "Reference Type", "Value Type", "Primitive Type" },
    { "Reference Type", "Value Type", "Nullable Type" },
    { "make", "create", "new" },
    { "Creates an object", "Iterates through a collection", "Compares values" },
    { "Automatically infers the type", "Deletes a variable", "Creates a class" },
    { "true", "false", "null" },
    { "1", "0", "-1" },
    { "Stops a loop", "Restarts a loop", "Skips a loop" },
    { "Ends a method", "Moves to the next iteration", "Exits the program" },
    { "switch", "foreach", "try-catch" },
    { "A method called when an object is created", "A loop", "An interface" },
    { "Zero", "Empty string", "No object reference" },
    { "Array", "List<T>", "Enum" },
    { "Converts an object to a string representation", "Creates a string", "Deletes a string" },
    { "Start()", "Run()", "Main()" }
};

            short[,] answersMatrix = {
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 },
    { 0, 1, 2 }
};

            short[] correctAnswersInds =
      {
    1, 0, 1, 2, 1,
    0, 1, 2, 1, 0,
    1, 1, 0, 1, 2,
    0, 2, 1, 0, 2
};

            for(int j = 0; j < questions.Length; j++)
            {
                short selected = 0;

                short i = 0;
                for (short k = 0; k < 3; k++)
                {
                    Random rand = new Random();
                    var randInd = rand.Next(0, 3);

                    var temp = answers[j, k];
                    answers[j, k] = answers[j, randInd];
                    answers[j, randInd] = temp;

                    var tempAnsMat = answersMatrix[j, k];
                    answersMatrix[j, k] = answersMatrix[j, randInd];
                    answersMatrix[j, randInd] = tempAnsMat;
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(questions[j]);

                    for (short k = 0; k < 3; k++)
                    {
                        if (k == selected)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("=> " + answers[j, k]);
                            Console.ResetColor();
                        }
                        else
                            Console.WriteLine("  " + answers[j, k]);
                    }

                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow && selected > 0)
                        selected--;

                    if (key.Key == ConsoleKey.DownArrow && selected < 2)
                        selected++;

                    if (key.Key == ConsoleKey.Enter)
                    {
                        if (answersMatrix[j, selected] == correctAnswersInds[j])
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.WriteLine("Correct!\n");
                            Console.ResetColor();  
                        }
                        else{
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("Wrong!\n");
                            Console.ResetColor();
                        }
                        i++;
                        Thread.Sleep(1500);
                        break;
                    }
                }
            }

            if (totalPoint <= 40)
                Console.WriteLine($"You failed. Your Score: {totalPoint}\n");
            else
                Console.WriteLine($"You passed. Your Score: {totalPoint}\n"); 
        } 
        static void quizMenu()
        {
            string[] menu = { "Start", "Rate Us", "Exit" };
            int selected = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(@"
  /$$$$$$  /$$   /$$ /$$$$$$ /$$$$$$$$
 /$$__  $$| $$  | $$|_  $$_/|_____ $$
| $$  \ $$| $$  | $$  | $$       /$$/
| $$  | $$| $$  | $$  | $$      /$$/
| $$  | $$| $$  | $$  | $$     /$$/
| $$/$$ $$| $$  | $$  | $$    /$$/
|  $$$$$$/|  $$$$$$/ /$$$$$$ /$$$$$$$$
 \____ $$$ \______/ |______/|________/
      \__/
");

                for (int i = 0; i < menu.Length; i++)
                { 
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("<< " + menu[i] + " >>");
                        Console.ResetColor(); 
                    }
                    else
                        Console.WriteLine("  " + menu[i]);
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && selected > 0)
                    selected--;

                if (key.Key == ConsoleKey.DownArrow && selected < menu.Length - 1)
                    selected++;

                if (key.Key == ConsoleKey.Enter)
                {
                    if (selected == 0) startQuiz();
                    else if (selected == 1) rateUs(); 
                    else if (selected == 2) break; 
                    break;
                }
            }
        }
        static void Main(string[] args)
        {
            quizMenu(); 
        }
    }
}

