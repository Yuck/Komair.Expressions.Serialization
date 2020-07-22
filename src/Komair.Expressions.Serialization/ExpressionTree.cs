using System;

namespace Komair.Expressions.Serialization
{
    public class ExpressionTree
    {
        public ExpressionNode Root { get; set; }

        public ExpressionTree(ExpressionNode root)
        {
            Root = root ?? throw new ArgumentNullException(nameof(root));
        }
    }
}