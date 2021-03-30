using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace CalculationExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Process.Start("C:\\Windows\\system32\\calc.exe");
            Thread.Sleep(3000);

            using StreamReader reader = new StreamReader(@"../../../Input.txt");
            try
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Expression expression = new Expression(line);

                    expression.startCalcAndWriterResult(@"../../../Output.txt");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
        }
    }
}