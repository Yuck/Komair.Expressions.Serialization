using Komair.Expressions.Abstract;

namespace Komair.Expressions.Serialization.Abstract
{
    public interface IExpressionNodeSerializer<T>
    {
        ExpressionNode Deserialize(T document);
        T Serialize(ExpressionNode node);
    }
}