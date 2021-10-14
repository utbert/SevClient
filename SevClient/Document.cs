using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SevDeskClient
{
    public class Document : SevClientObject<Document>
    {
        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "Document";

        [JsonProperty("additionalInformation")]
        public string AdditionalInformation { get; set; }

        [JsonProperty("create")]
        public DateTime? Create { get; set; }

        [JsonProperty("update")]
        public DateTime? _Update { get; set; }

        [JsonProperty("object")]
        public SevClientObject Object { get; set; }

        [JsonProperty("documentNumber")]
        public object DocumentNumber { get; set; }

        [JsonProperty("baseObject")]
        public SevClientObject BaseObject { get; set; }

        [JsonProperty("createUser")]
        public SevUser CreateUser { get; set; }

        [JsonProperty("updateUser")]
        public SevUser UpdateUser { get; set; }

        [JsonProperty("mimeType")]
        public string MimeType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("folder")]
        public DocumentFolder Folder { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("filesize")]
        public string Filesize { get; set; }

        public Stream Download() {

            RestRequest restRequest = new RestRequest();
            restRequest.Resource = $"{this.ObjectName}/{this.Id}/download";

            restRequest.AddParameter("id", this.Id);
            restRequest.AddParameter("download", "true");
            return new MemoryStream(restClient.DownloadData(restRequest));
        }

        public void Download(FileInfo fileInfo) {

            Stream downloadStream = this.Download();
            using (Stream writeStream = fileInfo.OpenWrite())
            {
                downloadStream.Seek(0, SeekOrigin.Begin);
                downloadStream.CopyTo(writeStream);
            }
            fileInfo.CreationTime = (DateTime)this.Create;
            fileInfo.LastWriteTimeUtc = (DateTime)this._Update;
        }

        public void FileUpload() { }
    }
}
