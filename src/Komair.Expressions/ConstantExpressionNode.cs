using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class ConstantExpressionNode : ExpressionNode
    {
        public Object Value { get; set; }

        public ConstantExpressionNode(ExpressionType nodeType, Type type) : base(nodeType, type) { }
    }
}