using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SevDeskClient
{
    class SevClientDataConverter : JsonConverter
    {
        public SevClientDataConverter()
        {

        }
        public override bool CanConvert(Type objectType)
        {
            return true;


        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Object)
            {
                string objectName = token["objectName"].Value<string>();
                Type type = Type.GetType($"SevDeskClient.{objectName}, SevClient") ?? typeof(SevClientObject);
                return token.ToObject(type, serializer);
            }

            return null;

        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }

    public class JsonIgnoreSerializationAttribute : Attribute { }

    class JsonPropertiesResolver : CamelCasePropertyNamesContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            //Return properties that do NOT have the JsonIgnoreSerializationAttribute
            return objectType.GetProperties()
                             .Where(pi => !Attribute.IsDefined(pi, typeof(JsonIgnoreSerializationAttribute)))
                             .ToList<MemberInfo>();
        }
    }
}
