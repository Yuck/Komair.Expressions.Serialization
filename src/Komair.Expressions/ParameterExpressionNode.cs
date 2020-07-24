using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class ParameterExpressionNode : ExpressionNode
    {
        public string Name { get; set; }

        public ParameterExpressionNode(ExpressionType nodeType, object type) : base(nodeType, type)
        {
        }
    }
}