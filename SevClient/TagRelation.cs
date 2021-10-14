using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SevDeskClient
{
    
    public class TagRelation : SevClientObject<TagRelation>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "TagRelation";
        /// <summary>date the tag relation was created</summary>
        public System.DateTimeOffset? Create { get; set; }

        /// <summary>tag which is has a relation to another object</summary>
        [Newtonsoft.Json.JsonProperty("tag")]
        public Tag Tag { get; set; }

        /// <summary>object type to which the tag is related</summary>
        [JsonProperty("object"), JsonConverter(typeof(SevClientDataConverter))]
        public SevClientObject Object { get; set; }

        /// <summary>sevClient is the unique Id every customer has and is used in nearly all operations</summary>
        //[Newtonsoft.Json.JsonProperty("sevClient", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public object SevClient { get; set; }
        public TagRelation()
        {
        }

        public static HttpStatusCode Add(Tag tag, SevClientObject sevClientObject, out TagRelation returnvalue)
        {
            TagRelation tagRelation = new TagRelation();
            tagRelation.Tag = tag;
            tagRelation.Object = sevClientObject;

            RestRequest restRequest = new RestRequest();
            restRequest.Resource = tagRelation.ObjectName;
            restRequest.AddJsonBody(tagRelation);
            restRequest.Method = Method.POST;


            IRestResponse response = restClient.Execute(restRequest);

            returnvalue = (JsonConvert.DeserializeAnonymousType(response.Content, new { objects = (TagRelation)Activator.CreateInstance(typeof(TagRelation)) }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore })).objects;
            //returnvalue = JsonConvert.DeserializeObject(response.Content, type: T[]);

            return response.StatusCode;
        }

    }
}
