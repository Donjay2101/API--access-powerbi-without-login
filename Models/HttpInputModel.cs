using System.Collections.Generic;
using System.Net.Http;

namespace API.PowerBI.Models
{
    public class HttpInputModel
    {
        public string BaseAddress { get; set; }
        public string Url { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> AuthorizationHeader { get; set; }
        public HttpContent Content { get; set; }
    }
}
