using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Text;
using Newtonsoft.Json;
using _10SoftDental.Providers;
using _10SoftDental.Models;
using ApplicationUtility;
//using _10SoftDental.BAL;


namespace _10SoftDental.Controllers
{

    public class LoginController : ApiController
    {
        public static Providers.Token _myToken;
        public static string ApiUri = ConfigurationManager.AppSettings["AppURL"].ToString();
        private readonly string errorMsg = "Incorrect Username (or) Password";
        //Transportal.BAL.Common.Common Common;
        private static async Task<HttpResponseMessage> CallApiTask(string apiEndPoint,
       Dictionary<string, string> model = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUri);
                client.DefaultRequestHeaders.Accept.Clear();
                if (_myToken != null)
                {
                    client.DefaultRequestHeaders.Authorization = new
                   AuthenticationHeaderValue("Bearer",
                    _myToken.AccessToken);
                }
                else
                {
                    client.DefaultRequestHeaders.Accept.Add(new
                   MediaTypeWithQualityHeaderValue("application/json"));
                }
                return await client.PostAsync(apiEndPoint, model != null ? new
               FormUrlEncodedContent(model) : null);
                // return await client.PostAsync("api/authtoken", model != null ? new
                //FormUrlEncodedContent(model) : null);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> ValidateUser(Login common)
        {
            try
            {
                //  object[] parameters = null;
                //Logger.Debug("Validate User", common.UserName,common.Password);
                //Common.ValidateUser();
                string tokenEmail = common.UserName;
                string tokenPassword = common.Password;
                if (String.IsNullOrEmpty(tokenEmail) || String.IsNullOrEmpty(tokenPassword))
                {
                    throw new ArgumentNullException();
                }

                var tokenModel = new Dictionary<string, string>
                 {
                 {"grant_type", "password"},
                 {"username", tokenEmail},
                 {"password", tokenPassword},
                 };
                var response = await CallApiTask("api/authtoken", tokenModel);
                if (!response.IsSuccessStatusCode)
                {
                   var errors = await response.Content.ReadAsStringAsync();
                    
                    throw new Exception(errors);
                }
                _myToken = response.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;

                return Ok(_myToken);
            }
            catch (Exception E)
            {
                Logger.Error(E,@"C:\DentalChartIcons\","error.txt");
                return Ok(E.Message.ToString());
            }
        }

    }
}
