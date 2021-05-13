using System;
using System.Linq;
using System.Linq.Expressions;
using Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode.Abstract;
using Mapster;

namespace Komair.Expressions.Mapping.Mapster.Configuration.Mappers.ExpressionNode
{
    internal class MemberExpressionNodeMapper : ExpressionNodeMapperBase<MemberExpressionNode, MemberExpression>
    {
        public MemberExpressionNodeMapper(TypeAdapterConfig configuration) : base(configuration) { }

        public override MemberExpression Map(MemberExpressionNode source)
        {
            var expression = source.Expression.Adapt<System.Linq.Expressions.Expression>(Configuration);
            var type = source.Expression.NodeType;
            var member = type.GetMember(source.MemberName).FirstOrDefault();
            // TODO: Test to cover this condition - need to start with a serialized expression like "".HelloWorld which we know doesn't exist
            if (member == null)
                throw new MemberAccessException($"Member '{source.MemberName}' was not found on type '{type.FullName}'.");

            var result = System.Linq.Expressions.Expression.MakeMemberAccess(expression, member);

            return result;
        }
    }
}