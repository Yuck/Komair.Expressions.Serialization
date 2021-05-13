using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class ParameterExpressionNode : ExpressionNode
    {
        public String Name { get; set; }

        public ParameterExpressionNode(ExpressionType expressionType, Type nodeType) : base(expressionType, nodeType) { }
    }
}