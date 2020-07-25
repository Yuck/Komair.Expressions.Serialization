using System;
using System.Linq;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class MemberExpressionNodeMapper : ExpressionNodeMapperBase<MemberExpressionNode, MemberExpression>
    {
        public MemberExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration)
        {
        }

        public override MemberExpression Map(MemberExpressionNode source)
        {
            var expression = source.Expression.Adapt<System.Linq.Expressions.Expression>(Configuration);
            var member = source.Expression.Type.GetMember(source.MemberName).FirstOrDefault();
            if (member == null)
                throw new MemberAccessException($"Member '{source.MemberName}' was not found on type '{source.Expression.Type.FullName}'.");

            var result = System.Linq.Expressions.Expression.MakeMemberAccess(expression, member);

            return result;
        }
    }
}