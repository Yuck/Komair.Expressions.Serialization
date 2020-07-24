using System.Collections.Generic;
using Komair.Expressions.Abstract;
using Komair.Expressions.Serialization.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Komair.Expressions.Serialization.Json
{
    public class JsonExpressionTreeSerializer : IExpressionNodeSerializer<JObject>
    {
        private readonly JsonSerializer _serializer;

        public JsonExpressionTreeSerializer(JsonSerializer serializer = null)
        {
            _serializer = serializer ?? JsonSerializer.Create(new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter()
                }
            });
        }

        public ExpressionNode Deserialize(JObject document)
        {
            return document.ToObject<ExpressionNode>(_serializer);
        }

        public JObject Serialize(ExpressionNode tree)
        {
            return JObject.FromObject(tree, _serializer);
        }
    }
}