namespace Komair.Expressions.Serialization.Abstract
{
    public interface IExpressionTreeSerializer<T>
    {
        ExpressionTree Deserialize(T document);
        T Serialize(ExpressionTree tree);
    }
}