using System.Linq.Expressions;

namespace Komair.Expressions
{
    public class ExpressionNode
    {
        // TODO: Should this be immutable?
        public ExpressionType NodeType { get; set; }
    }
}