using System.Linq.Expressions;
using Komair.Expressions.Abstract;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.Expression
{
    internal class MemberExpressionMapper : ExpressionMapperBase<MemberExpression, MemberExpressionNode>
    {
        public MemberExpressionMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override MemberExpressionNode Map(MemberExpression source)
        {
            var nodeType = source.NodeType;
            var type = source.Type;
            var result = new MemberExpressionNode(nodeType, type)
            {
                Expression = source.Expression.Adapt<ExpressionNodeBase>(Configuration),
                MemberName = source.Member.Name
            };

            return result;
        }
    }
}