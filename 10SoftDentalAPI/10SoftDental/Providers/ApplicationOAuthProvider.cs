using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Data;
using _10SoftDental.Helper;


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
                _10SoftDental.BAL.Common.CommonBAL _common = new _10SoftDental.BAL.Common.CommonBAL();
                DataSet _dataSet = new DataSet();
                Helper.EncryptionDecryption encryption = new EncryptionDecryption();
                _dataSet = _common.ValidateUser(context.UserName, encryption.GetEncrypt(context.Password));
                if (_dataSet != null)
                {

                    var Identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    Identity.AddClaim(new Claim("UserID", context.Password));
                    var props = new AuthenticationProperties(new Dictionary<string, string>
                        {
                            {
                                "UserEmail", _dataSet.Tables[0].Rows[0]["UserEmail"].ToString()
                            },
                            {
                                "IsActive", _dataSet.Tables[0].Rows[0]["IsActive"].ToString()
                            },

                            {
                                "UserName", _dataSet.Tables[0].Rows[0]["UserName"].ToString()
                            },
                            {
                                "BranchIdRef", _dataSet.Tables[0].Rows[0]["BranchIdRef"].ToString()
                            },
                            {
                                "UserId",_dataSet.Tables[0].Rows[0]["UserId"].ToString()
                            },
                            {
                                "ClinicId",_dataSet.Tables[0].Rows[0]["ClinicId"].ToString()
                            },
                            {
                                "IsSystemAdmin",_dataSet.Tables[0].Rows[0]["IsSystemAdmin"].ToString()
                            },
                             {
                                "UserEmployeePatientId",_dataSet.Tables[0].Rows[0]["UserEmployeePatientId"].ToString()
                            },
                              {
                                "JobGroupForeignName",_dataSet.Tables[0].Rows[0]["JobGroupForeignName"].ToString()
                            },
                               {
                                "JobGroupLocalName",_dataSet.Tables[0].Rows[0]["JobGroupLocalName"].ToString()
                            },
                                {
                                "JobGroupIdRef",_dataSet.Tables[0].Rows[0]["JobGroupIdRef"].ToString()
                            },
                         {
                                "UserType",_dataSet.Tables[0].Rows[0]["UserType"].ToString()
                            },
                        {
                                "ClinicIdRef",_dataSet.Tables[0].Rows[0]["ClinicIdRef"].ToString()
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