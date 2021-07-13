using System.Collections.Generic;

namespace API.PowerBI.Models
{
    public class BaseConfig
    {
        public AzureCconfig Azure { get; set; }
        public PowerBIConfig PowerBI { get; set; }
    }

    public class AzureCconfig
    {
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string TenantID { get; set; }
        public List<string> Scopes { get; set; }
        public string AuthorityUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; }
    }

    public class PowerBIConfig
    {
        public string ApplicationID { get; set; }
        public string ApplicationSecret { get; set; }
        public string ApiUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
