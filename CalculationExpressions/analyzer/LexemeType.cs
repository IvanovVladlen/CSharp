using System;
using System.Collections.Generic;
using System.Text;

namespace CalculationExpressions.analyzer
{
    public enum LexemeType
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
