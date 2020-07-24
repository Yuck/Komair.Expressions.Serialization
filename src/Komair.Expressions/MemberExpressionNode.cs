using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class MemberExpressionNode : ExpressionNode
    {
        public ExpressionNode Expression { get; set; }
        public string MemberName { get; set; }

        public MemberExpressionNode(ExpressionType nodeType, object type) : base(nodeType, type)
        {
        }
    }
}