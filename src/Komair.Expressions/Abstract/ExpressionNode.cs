using System.Linq.Expressions;

namespace Komair.Expressions.Abstract
{
    public abstract class ExpressionNode
    {
        public ExpressionType NodeType { get; }
        public object Type { get; }

        protected ExpressionNode(ExpressionType nodeType, object type)
        {
            NodeType = nodeType;
            Type = type;
        }
    }
}