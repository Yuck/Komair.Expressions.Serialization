using System;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class MemberExpressionNode : ExpressionNode
    {
        public ExpressionNode Expression { get; set; }
        public String MemberName { get; set; }

        public MemberExpressionNode(ExpressionType nodeType, Type type) : base(nodeType, type) { }
    }
}