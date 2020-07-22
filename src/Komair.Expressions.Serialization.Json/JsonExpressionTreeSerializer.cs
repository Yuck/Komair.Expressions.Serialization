using Komair.Expressions.Serialization.Abstract;
using Newtonsoft.Json.Linq;

namespace Komair.Expressions.Serialization.Json
{
    public class JsonExpressionTreeSerializer : IExpressionTreeSerializer<JObject>
    {
        public ExpressionTree Deserialize(JObject document)
        {
            return document.ToObject<ExpressionTree>();
        }

        public JObject Serialize(ExpressionTree tree)
        {
            return JObject.FromObject(tree);
        }
    }
}