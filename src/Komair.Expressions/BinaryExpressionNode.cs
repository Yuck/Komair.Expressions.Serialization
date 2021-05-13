using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class BinaryExpressionNode : ExpressionNode
    {
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }

        public BinaryExpressionNode(ExpressionType expressionType, Type nodeType) : base(expressionType, nodeType) { }
    }
}