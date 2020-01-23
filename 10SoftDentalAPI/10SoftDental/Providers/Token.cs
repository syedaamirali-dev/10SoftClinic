using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace _10SoftDental.Providers
{
    public class Token
    {
        
        [JsonProperty("Access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("UserId")]
        public string UserId { get; set; }
        [JsonProperty("UserName")]
        public string UserName { get; set; }
   
        [JsonProperty("IsSystemAdmin")]
        public string IsSystemAdmin { get; set; }
        [JsonProperty("IsActive")]
        public string IsActive { get; set; }
        [JsonProperty("ClinicIdRef")]
        public string ClinicIdRef { get; set; }

        [JsonProperty("JobGroupIdRef")]
        public string JobGroupIdRef { get; set; }

        [JsonProperty("UserType")]
        public string UserType { get; set; }
        [JsonProperty("UserEmployeePatientId")]
        public string UserEmployeePatientId { get; set; }
        [JsonProperty("JobGroupLocalName")]
        public string JobGroupLocalName { get; set; }
        [JsonProperty("JobGroupForeignName")]
        public string JobGroupForeignName { get; set; }
        [JsonProperty("BranchIdRef")]
        public string BranchIdRef { get; set; }
        [JsonProperty("ClinicId")]
        public string ClinicId { get; set; }
        [JsonProperty("UserEmail")]
        public string UserEmail { get; set; }
    }
}