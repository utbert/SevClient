using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class CommunicationWay : SevClientObject<CommunicationWay>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "CommunicationWay";
        public string create { get; set; }
        public string update { get; set; }
        public Contact contact { get; set; }
        public string type { get; set; }

        [JsonProperty("Key")]
        public CommunicationWayKey key { get; set; }
        public string value { get; set; }
        public string main { get; set; }

        public class CommunicationWayKey : SevClientObject<CommunicationWayKey>
        {
            [JsonProperty("objectName")]
            public override string ObjectName { get; set; } = "CommunicationWayKey";
            public override string Id
            {
                get { return ((int)IdEnum).ToString();  }
                set
                {
                    communicationWayKeyID wayKeyID; 
                    if (Enum.TryParse<communicationWayKeyID>(value, out wayKeyID))
                    {
                        this.IdEnum = wayKeyID;
                    } 
                }
            }

            [JsonIgnoreAttribute]
            public communicationWayKeyID IdEnum { get; set; }
        }

        public CommunicationWay()
        {

        }

        public enum communicationWayKeyID
        {
            Arbeit = 2,
            Autobox = 6,
            Fax = 3,
            Mobil = 4,
            Newsletter = 7,
            Privat = 1,
            Rechnungsadresse = 8,
            empty = 5

        }
    }


}
