using System;

namespace Komair.Expressions.Serialization
{
    void Main()
    {
        // TODO: ... Mapster.TypeAdapterConfig.GlobalSettings;

        Func<IExpressionNodeMapper<string, bool>> getMapper = () => new MapsterExpressionNodeMapper<string, bool>();
        Func<IExpressionTreeSerializer<JObject>> getSerializer = () => new JsonExpressionTreeSerializer();
        Expression<Func<string, bool>> x = t => t.Length > 0;

        var value = "test";
        var test1 = x.Compile()(value).Dump();

        var mapper = getMapper(); // this would come via DI
        var serializer = getSerializer(); // this would come via DI

        var tree1 = new ExpressionTree(mapper.ToExpressionNode(x));
        var serialized = serializer.Serialize(tree1);
        var deserialized = serializer.Deserialize(serialized);
        var tree2 = mapper.ToExpression(deserialized.Root);

        var xxx = tree2.Compile();

        var test2 = xxx(value).Dump();
    }

    public class MapsterExpressionNodeMapper<T, TResult> : IExpressionNodeMapper<T, TResult>
    {
        public Expression<Func<T, TResult>> ToExpression(ExpressionNode expression)
        {
            var type = typeof(T);
            var parameter = Expression.Parameter(type, "arg");
            var memberInfo = type.GetMember("Length").First();
            var left = Expression.MakeMemberAccess(parameter, memberInfo);
            var right = Expression.Constant(10);
            var body = Expression.GreaterThan(left, right);
            // TODO: why is this saying that there are an incorrect number of parameters?
            var lammy = Expression.Lambda<Func<T, TResult>>(body);

            return lammy;
        }

        public ExpressionNode ToExpressionNode(Expression<Func<T, TResult>> expression)
        {
            return expression.Adapt<ExpressionNode>();
        }
    }



    // Factory for serialization based on format
    // Individual implementations like XML, JSON, binary, BSON, other?





    //public class BinaryExpressionNode : ExpressionNode
    //{
    //    public ExpressionNode Left { get; set; }
    //    public ExpressionNode Right { get; set; }
    //}

    //public static class ExpressionExtensions
    //{
    //    public static ExpressionNode ToExpressionNode(this Expression expression)
    //    {
    //        if (expression is BinaryExpression binary)
    //            return null;

    //        return null;
    //    }
    //}

    //public static class BinaryExpressionExtensions
    //{
    //    public static BinaryExpressionNode ToXXX(this BinaryExpression expression)
    //    {
    //        if (expression == null)
    //            throw new ArgumentNullException(nameof(expression));

    //        return new BinaryExpressionNode();
    //    }
    //}

  
}
