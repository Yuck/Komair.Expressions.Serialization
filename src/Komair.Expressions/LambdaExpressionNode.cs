using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Komair.Expressions.Abstract;

namespace Komair.Expressions
{
    public class LambdaExpressionNode : ExpressionNode
    {
        public ExpressionNode Body { get; set; }
        public IEnumerable<ParameterExpressionNode> Parameters { get; set; }
        public Type ReturnType { get; set; }

        public LambdaExpressionNode(ExpressionType nodeType, object type) : base(nodeType, type)
        {
        }
    }
}