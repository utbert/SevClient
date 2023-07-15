using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SevDeskClient
{
    public class ContactCustomField : SevClientObject<ContactCustomField>
    {

        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "ContactCustomField";

        [JsonProperty("additionalInformation")]
        public object AdditionalInformation { get; set; }

        [JsonProperty("create")]
        public DateTime? Create { get; set; }

        [JsonProperty("update")]
        public DateTime? _Update { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("contactCustomFieldSetting")]
        public ContactCustomFieldSetting ContactCustomFieldSetting { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        public ContactCustomField()
        { 
        }

        public static HttpStatusCode Add(ContactCustomFieldSetting setting, Contact contact,string value, out ContactCustomField returnvalue)
        {
            ContactCustomField contactCustomField = new ContactCustomField();
            contactCustomField.ContactCustomFieldSetting = setting;
            contactCustomField.Contact = contact;
            contactCustomField.Value = value;

            RestRequest restRequest = new RestRequest();
            restRequest.Resource = contactCustomField.ObjectName;
            restRequest.AddJsonBody(contactCustomField);
            restRequest.Method = Method.Post;


            RestResponse response = restClient.ExecuteAsync(restRequest).Result;

            returnvalue = (JsonConvert.DeserializeAnonymousType(response.Content, new { objects = (ContactCustomField)Activator.CreateInstance(typeof(ContactCustomField)) }, new JsonSerializerSettings() { MissingMemberHandling = MissingMemberHandling.Ignore })).objects;
            //returnvalue = JsonConvert.DeserializeObject(response.Content, type: T[]);

            return response.StatusCode;
        }

    }
}
