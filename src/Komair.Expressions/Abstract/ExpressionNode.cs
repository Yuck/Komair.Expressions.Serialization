using System;
using System.Linq.Expressions;

namespace Komair.Expressions.Abstract
{
    public abstract class ExpressionNode
    {
        public ExpressionType ExpressionType { get; }
        public Type NodeType { get; } // TODO: May not really need the whole type construct

        protected ExpressionNode(ExpressionType expressionType, Type nodeType)
        {
            ExpressionType = expressionType;
            NodeType = nodeType;
        }
    }
}