using System;
using System.Linq.Expressions;

namespace Komair.Expressions.Abstract
{
    public abstract class ExpressionNode
    {
        public ExpressionType NodeType { get; }
        public Type Type { get; } // TODO: May not really need the whole type construct

        protected ExpressionNode(ExpressionType nodeType, Type type)
        {
            NodeType = nodeType;
            Type = type;
        }
    }
}