using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions;

public class ParameterExpressionNode : ExpressionNodeBase
{
    public String Name { get; set; }

    public ParameterExpressionNode(ExpressionType nodeType, Type type) : base(nodeType, type) { }
}
