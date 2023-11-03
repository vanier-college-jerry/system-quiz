using System;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            //ex1();
            //ex2();
            //ex3();
            //ex4();
            ex5();
        }

        static void ex1()
        {
            Console.Write("Hello: ");
            Console.Write("Jolson Cruz");
        }

        static void ex2()
        {
            int num1 = 5;
            int num2 = 7;
            int sum = num1 + num2;

            Console.Write("The sum of " + num1 + " and " + num2 + " is: " + sum);
        }

        static void ex3()
        {
            int num1 = 10;
            int num2 = 5;
            int quotient = num1 / num2;

            Console.Write("The quotient of " + num1 + " and " + num2 + " is: " + quotient);
        }

        static void ex4()
        {
            double res1 = -1 + 4 * 6;
            double res2 = (35 + 5)  % 7;
            double res3 = 14 + -4 * 6 / 11;
            double res4 = 2 + 15 / 6 * 1 - 7 % 2;

            Console.WriteLine("The result of -1 + 4 * 6 is: " + res1);
            Console.WriteLine("The result of (35 + 5) % 7 is: " + res2);
            Console.WriteLine("The result of 14 + -4 * 6 / 11 is: " + res3);
            Console.WriteLine("The result of 2 + 15 / 6 * 1 - 7 % 2 is: " + res4);
        }

        static void ex5()
        {
            Console.Write("Input number 1: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Input number 2: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("\nOriginal num1: " + num1);
            Console.WriteLine("Original num2: " + num2);
            Console.WriteLine("Swapped num1: " + (num1-(num1-num2)));
            Console.WriteLine("Swapped num2: " + (num2+(num1-num2)));
        }
    }
}
