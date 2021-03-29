using System;

namespace ExpressionParser.exception
{
    class PositionLexemeException : Exception
    {
        public PositionLexemeException(String message) : base(String.Format("Unexpected lexeme %s at position", message))
        {
        }
    }
}