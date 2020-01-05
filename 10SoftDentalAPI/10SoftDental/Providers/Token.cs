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
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("RoleID")]
        public string RoleID { get; set; }
   
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("UserID")]
        public string UserID { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("IsAdmin")]
        public string IsAdmin { get; set; }
    }
}