using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SevDeskClient
{
    public class SevUser : SevClientObject<SevUser>
    {
        [JsonProperty("id")]
        public override string Id { get; set; } = "236508";

        [JsonProperty("objectName")]
        public override string ObjectName { get; set; } = "SevUser";

        [JsonProperty("additionalInformation")]
        public object AdditionalInformation { get; set; }

        [JsonProperty("create")]
        public DateTime Create { get; set; }

        [JsonProperty("update")]
        public DateTime Update { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("memberCode")]
        public string MemberCode { get; set; }

        [JsonProperty("sevClient")]
        public SevClient SevClient { get; set; }

        [JsonProperty("lastLogin")]
        public DateTime? LastLogin { get; set; }

        [JsonProperty("lastLoginIp")]
        public string LastLoginIp { get; set; }

        [JsonProperty("welcomeScreenSeen")]
        public string WelcomeScreenSeen { get; set; }

        [JsonProperty("smtpName")]
        public string SmtpName { get; set; }

        [JsonProperty("smtpMail")]
        public string SmtpMail { get; set; }

        [JsonProperty("smtpUser")]
        public string SmtpUser { get; set; }

        [JsonProperty("smtpPort")]
        public string SmtpPort { get; set; }

        [JsonProperty("smtpSsl")]
        public string SmtpSsl { get; set; }

        [JsonProperty("smtpHost")]
        public string SmtpHost { get; set; }

        [JsonProperty("languageCode")]
        public string LanguageCode { get; set; }

        [JsonProperty("twoFactorAuth")]
        public string TwoFactorAuth { get; set; }

        [JsonProperty("forcePasswordChange")]
        public string ForcePasswordChange { get; set; }

        [JsonProperty("clientOwner")]
        public string ClientOwner { get; set; }

        [JsonProperty("defaultReceiveMailCopy")]
        public string DefaultReceiveMailCopy { get; set; }

        [JsonProperty("hideMapsDirections")]
        public string HideMapsDirections { get; set; }

        [JsonProperty("startDate")]
        public object StartDate { get; set; }

        [JsonProperty("endDate")]
        public object EndDate { get; set; }

        [JsonProperty("lastPasswordChange")]
        public DateTime? LastPasswordChange { get; set; }

        public SevUser() { }
    }


}
