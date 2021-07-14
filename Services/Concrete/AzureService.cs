using API.PowerBI.Constants;
using API.PowerBI.Extensions;
using API.PowerBI.Models;
using API.PowerBI.Services.Abstract;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.PowerBI.Services.Concrete
{
    public class AzureService : IAzureService
    {
        private BaseConfig _config;

        public AzureService(IOptions<BaseConfig> config)
        {
            _config = config.Value;
        }
        public async Task<string> GetAccessToken()
        {
            if(!IsTokenValid())
            {
                var form = new Dictionary<string, string>();
                form["grant_type"] = _config.Azure.GrantType;
                //form["username"] = _config.Azure.Username;
                //form["password"] = _config.Azure.Password;
                form["client_id"] = _config.Azure.ClientID;
                form["client_secret"] = _config.Azure.ClientSecret;
                form["scope"] = string.Join(" ",_config.Azure.Scopes);
                var content = new FormUrlEncodedContent(form);

                var input = new HttpInputModel
                {
                    BaseAddress = $"{_config.Azure.AuthorityUrl}/{_config.Azure.TenantID}/",
                    Content = content,
                    Headers = new Dictionary<string, string>
                        {
                            { "Content-Type","application/x-www-form-urlencoded" }
                        },
                    Url = "oauth2/v2.0/token"
                };
                var response = await HttpService.Inastnce.Post(input);
                if (response != null && response.IsSuccessStatusCode)
                {
                    var res = JsonConvert.DeserializeObject<AccessToken>(await response.Content.ReadAsStringAsync());
                    Common.AccessToken = res.Token;
                }
            }

            return Common.AccessToken;

        }
        private bool IsTokenValid()
        {
            if (string.IsNullOrWhiteSpace(Common.AccessToken))
            {
                return false;
            }
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(Common.AccessToken) as JwtSecurityToken;
            return jsonToken.ValidTo.IsValid();
        }
    }
}
