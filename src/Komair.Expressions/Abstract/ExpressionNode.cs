using System;
using System.Linq.Expressions;

namespace Komair.Expressions.Abstract
{
    public abstract class ExpressionNode
    {
        public ExpressionType NodeType { get; }
        public Type Type { get; }

        protected ExpressionNode(ExpressionType nodeType, Type type)
        {
            NodeType = nodeType;
            Type = type;
        }
    }
}