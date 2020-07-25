using Komair.Expressions.Abstract;

namespace Komair.Expressions.Serialization.Abstract
{
    public interface IExpressionNodeSerializer<T, TExpressionNode> where TExpressionNode : ExpressionNode
    {
        TExpressionNode Deserialize(T document);
        T Serialize(TExpressionNode node);
    }
}