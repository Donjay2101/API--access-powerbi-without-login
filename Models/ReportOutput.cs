using Microsoft.PowerBI.Api.Models;
using System;

namespace API.PowerBI.Models
{
    public class ReportOutput
    {
        public string Id { get; set; }
        public string EmbedUrl { get; set; }
        public EmbedToken EmbdedToken { get; set; }
        public int MinutesToExpiration
        {
            get
            {
                var minutesToExpiration = EmbdedToken.Expiration - DateTime.UtcNow;
                return minutesToExpiration.Minutes;
            }
        }

        public bool? IsEffectiveIdentityRolesRequired { get; set; }
        public bool? IsEffectiveIdentityRequired { get; set; }
        public bool EnableRLS { get; set; }
        public string Username { get; set; }
        public string Roles { get; set; }
        public string ErrorMessage { get; internal set; }
    }
}
