using ExpressionParser.parser;
using System;
using System.IO;

namespace ExpressionParser
{
    class Program
    {
        static void Main(string[] args)
        {
            using StreamReader reader = new StreamReader(@"../../../Input.txt");
            try
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Expression expression = new Expression(line); //создание объекта выражения и передача ему строки с выражением

                    using StreamWriter writer = new StreamWriter(@"../../../Output.txt", true);
                    try
                    {
                        writer.WriteLine(expression.Calc()); //запись результата выражения в файл
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine("File path not specified." + e);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File path not specified." + e);
            }
        }
    }
}