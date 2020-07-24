using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class ConstantExpressionNode : ExpressionNode
    {
        public object Value { get; set; }

        public ConstantExpressionNode(ExpressionType nodeType, object type) : base(nodeType, type)
        {
        }
    }
}