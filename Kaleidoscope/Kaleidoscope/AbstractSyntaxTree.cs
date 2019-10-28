using System;

namespace Kaleidoscope
{
    /// <summary>
    /// Base class for all expression nodes.
    /// </summary>
    public abstract class ExprAST
    {
        protected ExprAST() {}
    }

    /// <summary>
    /// Expression class for numeric literals like "1.0".
    /// </summary>
    public sealed class NumberExprAST : ExprAST
    {
        public double Value { get; }

        public NumberExprAST(double value)
        {
            Value = value;
        }
    }

    /// <summary>
    /// Expression class for referencing a variable, like "a".
    /// </summary>
    public sealed class VariableExprAST : ExprAST
    {
        public string Name { get; }

        public VariableExprAST(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }

    /// <summary>
    /// Expression class for a binary operator.
    /// </summary>
    public class BinaryExprAST : ExprAST
    {
        public char Operator { get; }
        public ExprAST Left { get; }
        public ExprAST Right { get; }

        public BinaryExprAST(char @operator, ExprAST left, ExprAST right)
        {
            Operator = @operator;
            Left = left ?? throw new ArgumentNullException(nameof(left));
            Right = right ?? throw new ArgumentNullException(nameof(right));
        }
    }

    /// <summary>
    /// Expression class for function calls.
    /// </summary>
    public class CallExprAST : ExprAST
    {
        public string Callee { get; }
        public ExprAST[] Args { get; }

        public CallExprAST(string callee, ExprAST[] args)
        {
            Callee = callee ?? throw new ArgumentNullException(nameof(callee));
            Args = args ?? throw new ArgumentNullException(nameof(args));
        }
    }

    /// <summary>
    /// This class represents the "prototype" for a function,
    /// which captures its name, and its argument names
    /// (thus implicitly the number of arguments the function takes).
    /// </summary>
    public class PrototypeAST : ExprAST
    {
        public string Name { get; }
        public string[] Args { get; }

        public PrototypeAST(string name, string[] args)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Args = args ?? throw new ArgumentNullException(nameof(args));
        }
    }

    /// <summary>
    /// This class represents a function definition itself.
    /// </summary>
    public class FunctionAST : ExprAST
    {
        public PrototypeAST Protptype { get;  }
        public ExprAST Body { get; }

        public FunctionAST(PrototypeAST protptype, ExprAST body)
        {
            Protptype = protptype ?? throw new ArgumentNullException(nameof(protptype));
            Body = body ?? throw new ArgumentNullException(nameof(body));
        }
    }
}