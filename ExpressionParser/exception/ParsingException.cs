using System;

namespace ExpressionParser.exception
{
    public class ParsingException : Exception
    {
        public ParsingException(String message) : base(message)
        {
        }
    }
}