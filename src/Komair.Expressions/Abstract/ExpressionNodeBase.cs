using System;
using System.Linq.Expressions;

namespace Komair.Expressions.Abstract;

public abstract class ExpressionNodeBase
{
    public ExpressionType NodeType { get; }
    public Type Type { get; }

    protected ExpressionNodeBase(ExpressionType nodeType, Type type)
    {
        NodeType = nodeType;
        Type = type;
    }
}
