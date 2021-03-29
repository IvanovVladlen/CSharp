using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionParser.Lexemes
{
    enum LexemeType
    {
        Number,
        Plus,
        Minus,
        Mul,
        Div,
        LeftBracket,
        RightBracket,
        End
    }
}