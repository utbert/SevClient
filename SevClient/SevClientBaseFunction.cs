using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static SevDeskClient.SevClient;

namespace SevDeskClient
{

    public class SevClientObject : SevClient
    {
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("objectName")]
        public virtual string ObjectName { get; set; }
    }
    public abstract class SevClientObject<T> : SevClientObject where T : SevClientObject<T>, new()
    {
        //[JsonProperty("id")]
        //public virtual string Id { get; set; }

        //[JsonProperty("objectName")]
        //public virtual string ObjectName { get; set; }

        public static List<T> GetList(int limit = 0, string[] embed = null, KeyValuePair<string, string>[] filter = null)
        {

            //Type listType = typeof(List<>);
            //Type constructedListType = listType.MakeGenericType(typeof(T).GetType());

            RestRequest restRequest = new RestRequest();
            restRequest.Resource = new T().ObjectName;
            restRequest.AddParameter("depth", "1");
            restRequest.AddParameter("limit", "200");
            restRequest.AddParameter("offset", "0");
            restRequest.AddParameter("countAll", "1");

            if (filter != null)
            {
                foreach (var item in filter)
                {
                    restRequest.AddParameter(item.Key, item.Value);
                }

            }

            if (embed != null)
            {
                foreach (var item in embed)
                {
                    embed[Array.IndexOf(embed, item)] = item;
                }
                restRequest.AddParameter("embed", String.Join(",", embed));
            }
            RestResponse response = restClient.GetAsync(restRequest).Result;

            var deserialized = JsonConvert.DeserializeAnonymousType(response.Content, new { total = new int?(), objects = new List<T>() }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore, NullValueHandling = NullValueHandling.Ignore });
            
            if (limit == 0 & deserialized.objects != null)
            {
                
                limit = 200;
                while (deserialized.objects.Count < deserialized.total - 1)
                {
                    //var test = restRequest.Parameters.Find(f => f.Name == "offset").Value;
                    restRequest.AddOrUpdateParameter("offset", limit);
                    limit = limit + 200;

                    response = restClient.GetAsync(restRequest).Result;
                    deserialized.objects.AddRange(JsonConvert.DeserializeAnonymousType(response.Content, new { total = new int(), objects = new List<T>() }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore, NullValueHandling = NullValueHandling.Ignore }).objects.ToList());
                }
            }

            return deserialized.objects == null ? new List<T>() : deserialized.objects.ToList();
        }
        public HttpStatusCode Update()
        {

            RestRequest restRequest = new RestRequest();
            restRequest.Resource = $"{ObjectName}/{this.Id}";

            restRequest.AddJsonBody(this);
            restRequest.RequestFormat = DataFormat.Json;
            RestResponse response = restClient.PutAsync(restRequest).Result;

            object returnvalue = (JsonConvert.DeserializeAnonymousType(response.Content, new { objects = new object() }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore })).objects;
            return response.StatusCode;
        }
        public HttpStatusCode Add(out T returnvalue)
        {

            RestRequest restRequest = new RestRequest();
            restRequest.Resource = ObjectName;
            restRequest.AddJsonBody(this);

            RestResponse response = restClient.PostAsync(restRequest).Result;

            returnvalue = (JsonConvert.DeserializeAnonymousType(response.Content, new { objects = (T)Activator.CreateInstance(typeof(T)) }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore })).objects;
            //returnvalue = JsonConvert.DeserializeObject(response.Content, type: T[]);

            return response.StatusCode;
        }
        public HttpStatusCode Delete()
        {

            RestRequest restRequest = new RestRequest();
            restRequest.Resource = $"{ObjectName}/{this.Id}";
            restRequest.AddParameter("id", this.Id);


            RestResponse response = restClient.DeleteAsync(restRequest).Result;
            return response.StatusCode;
        }
    }

    public abstract class SevClientPdfObject<T> : SevClientObject<T> where T : SevClientPdfObject<T>, new()
    {
        public Stream getPdf()
        {
            RestRequest restRequest = new RestRequest();
            restRequest.Resource = $"{this.ObjectName}/{this.Id}/getPdf";
            //restRequest.Timeout = 60000;
            restRequest.AddParameter("id", this.Id);
            restRequest.AddParameter("download", "true");

            byte[] response = restClient.DownloadDataAsync(restRequest).Result;
            return new MemoryStream(response);

        }
    }
}
