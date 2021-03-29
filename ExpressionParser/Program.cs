﻿using ExpressionParser.parser;
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

                    using StreamWriter sw = new StreamWriter(@"../../../Output.txt", true);
                    try
                    {
                        sw.WriteLine(Convert.ToString(parser.calc()));
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