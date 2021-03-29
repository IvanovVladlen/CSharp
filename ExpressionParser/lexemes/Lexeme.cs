namespace ExpressionParser.Lexemes
{
    class Lexeme
    {
        private LexemeType LexemeType;
        private string Value;

        public LexemeType GetLexemeType()
        {
            return LexemeType;
        }
        public string GetValue()
        {
            return Value;
        }
        public Lexeme(LexemeType lexemeType, string value)
        {
            LexemeType = lexemeType;
            Value = value;
        }
    }
}