using Komair.Expressions.Serialization.Abstract;
using Newtonsoft.Json.Linq;

namespace Komair.Expressions.Serialization.Json
{
    public class JsonExpressionTreeSerializer : IExpressionNodeSerializer<JObject>
    {
        public ExpressionNode Deserialize(JObject document)
        {
            return document.ToObject<ExpressionNode>();
        }

        public JObject Serialize(ExpressionNode tree)
        {
            return JObject.FromObject(tree);
        }
    }
}