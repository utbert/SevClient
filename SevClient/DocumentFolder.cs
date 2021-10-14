using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SevDeskClient
{
    public class DocumentFolder : SevClientObject<DocumentFolder>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "DocumentFolder";

        [JsonProperty("additionalInformation")]
        public string AdditionalInformation { get; set; }

        [JsonProperty("create")]
        public DateTime? Create { get; set; }

        [JsonProperty("update")]
        public DateTime? _Update { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("parent")]
        public DocumentFolder Parent { get; set; }

        [JsonProperty("object")]
        public SevClientObject Object { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("translationCode")]
        public object TranslationCode { get; set; }

        public List<DocumentFolder> GetChildFolder(List<DocumentFolder> documentFolders = null)
        {
            List<DocumentFolder> folders = SevDesk.documentFolders.Where(s => s.Parent?.Id == this.Id).ToList();
            return folders;
        }

        public List<Document> GetDocuments()
        {
            return SevDesk.documents.Where(w => w.Folder?.Id == this.Id).ToList();
        }
    }
}
