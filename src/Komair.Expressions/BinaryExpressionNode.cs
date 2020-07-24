using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class BinaryExpressionNode : ExpressionNode
    {
        public ExpressionNode Left { get; set; }
        public ExpressionNode Right { get; set; }

        public BinaryExpressionNode(ExpressionType nodeType, object type) : base(nodeType, type)
        {
        }
    }
}