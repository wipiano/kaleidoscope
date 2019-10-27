namespace Kaleidoscope
{
    public abstract class Token
    {
    }

    public sealed class EndOfFileToken : Token
    {
        public static readonly EndOfFileToken Value = new EndOfFileToken();
        private EndOfFileToken() {}
    }

    public sealed class UnknownToken : Token
    {
        public string Value { get; }

        public UnknownToken(string value)
        {
            Value = value;
        }
    }

    public sealed class DefToken : Token
    {
        public static readonly DefToken Value = new DefToken();
        private DefToken() {}
    }

    public sealed class ExternToken : Token
    {
        public static readonly ExternToken Value = new ExternToken();
        private ExternToken() {}
    }

    public sealed class IdentifierToken : Token
    {
        public string Value { get; }
        public IdentifierToken(string value)
        {
            Value = value;
        }
    }

    public sealed class NumberToken : Token
    {
        public double Value { get; }
        public NumberToken(double value)
        {
            Value = value;
        }
    }
}