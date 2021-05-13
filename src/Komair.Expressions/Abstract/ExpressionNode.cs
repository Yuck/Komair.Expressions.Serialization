using System;
using System.Linq.Expressions;

namespace Komair.Expressions.Abstract
{
    public abstract class ExpressionNode
    {
        public ExpressionType ExpressionType { get; }
        public Type NodeType { get; }

        protected ExpressionNode(ExpressionType expressionType, Type nodeType)
        {
            ExpressionType = expressionType;
            NodeType = nodeType;
        }
    }
}