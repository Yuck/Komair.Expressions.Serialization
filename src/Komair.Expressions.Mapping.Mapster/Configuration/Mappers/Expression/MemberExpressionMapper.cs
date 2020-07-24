using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class MemberExpressionMapper : ExpressionMapperBase<MemberExpression, MemberExpressionNode>
    {
        public MemberExpressionMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override MemberExpressionNode Map(MemberExpression source)
        {
            var result = new MemberExpressionNode(source.NodeType, source.Type)
            {
                Expression = source.Expression.Adapt<Expressions.Abstract.ExpressionNode>(Configuration),
                MemberName = source.Member.Name
            };

            return result;
        }
    }
}