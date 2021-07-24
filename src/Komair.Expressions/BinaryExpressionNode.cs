using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class BinaryExpressionNode : ExpressionNodeBase
    {
        public ExpressionNodeBase Left { get; set; }
        public ExpressionNodeBase Right { get; set; }

        public BinaryExpressionNode(ExpressionType nodeType, Type type) : base(nodeType, type) { }
    }
}