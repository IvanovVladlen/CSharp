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
                    Parser parser = new Parser(line);

                    using StreamWriter writer = new StreamWriter(@"../../../Output.txt", true);
                    try
                    {
                        writer.WriteLine(parser.Calc());
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