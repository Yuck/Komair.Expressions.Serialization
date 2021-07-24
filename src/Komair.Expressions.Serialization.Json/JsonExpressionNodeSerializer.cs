using Komair.Expressions.Abstract;
using Komair.Expressions.Serialization.Abstract;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// TODO: Eventually try to use System.Text.Json, but for now its serializer is pretty hard to work with
namespace Komair.Expressions.Serialization.Json
{
    public class JsonExpressionNodeSerializer<TExpressionNode> : IExpressionNodeSerializer<JObject, TExpressionNode> where TExpressionNode : ExpressionNodeBase
    {
        #region Private Members

        private readonly JsonSerializerSettings _settings;

        #endregion


        #region Constructors

        public JsonExpressionNodeSerializer(JsonSerializerSettings settings = null)
        {
            _settings = settings;
        }

        #endregion


        #region Public Methods

        public TExpressionNode Deserialize(JObject document) => JsonConvert.DeserializeObject<TExpressionNode>(document.ToString(), _settings);

        public JObject Serialize(TExpressionNode node) => JObject.Parse(JsonConvert.SerializeObject(node, _settings));

        #endregion
    }
}