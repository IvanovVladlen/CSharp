using System;

namespace ExpressionParser.exception
{
    public class InvalidLexemeException : Exception
    {
        public InvalidLexemeException(String message, int index) : base(String.Format("unknown lexeme %s at position %d", message, index + 1))
        {
        }
    }
}