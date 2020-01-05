using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using _10SoftDental.Models;
using System.Data;


namespace _10SoftDental.Providers
{

    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private string count;
        private readonly string _publicClientId;

        private DataSet _dataSet = null;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                //MobWeb_BAL.Common.Common _common = new MobWeb_BAL.Common.Common();
                DataSet _dataSet = new DataSet();
               // _dataSet = _common.ValidateUser(context.UserName, context.Password);
                if (_dataSet!= null)
                {

                    var Identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    Identity.AddClaim(new Claim("UserID", context.Password));
                    var props = new AuthenticationProperties(new Dictionary<string, string>
                        {
                            {
                                "Email", _dataSet.Tables[0].Rows[0]["Email"].ToString()
                            },
                            {
                                "RoleID", _dataSet.Tables[0].Rows[0]["RoleID"].ToString()
                            },

                            {
                                "FirstName", _dataSet.Tables[0].Rows[0]["FirstName"].ToString()
                            },
                            {
                                "LastName", _dataSet.Tables[0].Rows[0]["LastName"].ToString()
                            },
                            {
                                "UserID",_dataSet.Tables[0].Rows[0]["UserID"].ToString()
                            },
                            {
                                "Phone",_dataSet.Tables[0].Rows[0]["Phone"].ToString()
                            },
                            {
                                "IsAdmin",_dataSet.Tables[0].Rows[0]["IsAdmin"].ToString()
                            }

                        });
                    AuthenticationTicket ticket = new AuthenticationTicket(Identity, props);
                    context.Validated(Identity);
                    context.Validated(ticket);
                }
                else
                {
                    context.SetError("User Identification Number Not Valid");
                    return;
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }

        public static AuthenticationProperties CreateProperties(string userName, string password)
        {
           // MobWeb_BAL.Common.Common _common = new MobWeb_BAL.Common.Common();
            DataSet _dataSet = new DataSet();
            //_dataSet = _common.ValidateUser(userName, password);
            if (Convert.ToInt32(_dataSet.Tables[0].Rows[0][0]) != 0)
            {
                IDictionary<string, string> data = new Dictionary<string, string>
            {
              {
                                "Email", _dataSet.Tables[0].Rows[0]["Email"].ToString()
                            },
                            {
                                "RoleID", _dataSet.Tables[0].Rows[0]["RoleID"].ToString()
                            },

                            {
                                "FirstName", _dataSet.Tables[0].Rows[0]["FirstName"].ToString()
                            },
                            {
                                "LastName", _dataSet.Tables[0].Rows[0]["LastName"].ToString()
                            },
                            {
                                "UserID",_dataSet.Tables[0].Rows[0]["UserID"].ToString()
                            },
                            {
                                "Phone",_dataSet.Tables[0].Rows[0]["Phone"].ToString()
                            },

            };
                return new AuthenticationProperties(data);
            }
            else
            {

                IDictionary<string, string> data = new Dictionary<string, string>
            {
                                {
                                "Invalid", "Username or Password incorrect"
                            },

            };
                return new AuthenticationProperties(data);
            }

        }
    }
}