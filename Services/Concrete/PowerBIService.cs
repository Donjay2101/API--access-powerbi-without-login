using API.PowerBI.Models;
using API.PowerBI.Services.Abstract;
using Microsoft.Extensions.Options;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using System;
using System.Threading.Tasks;

namespace API.PowerBI.Services.Concrete
{
    public class PowerBIService : IPowerBIService
    {
        private readonly IAzureService _azureService;
        private readonly BaseConfig _config;
        private PowerBIClient _client;

        public PowerBIService(IOptions<BaseConfig> config, IAzureService azureService)
        {
            _azureService = azureService;
            _config = config.Value;
        }

        public async Task<ReportOutput> GetReport(ReportInput reportInput)
        {
            await PowerBIClient();
            var workspaceId = reportInput.WorkspaceID;
            var reportId = reportInput.ReportID;
            var report = await _client.Reports.GetReportInGroupAsync(workspaceId, reportId);
            var generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "view");
            var tokenResponse = await _client.Reports.GenerateTokenAsync(workspaceId, reportId, generateTokenRequestParameters);
            var output = new ReportOutput
            {
                Username = _config.PowerBI.Username,
                EmbdedToken = tokenResponse,
                EmbedUrl = report.EmbedUrl,
                Id = reportInput.ReportID.ToString()
            };
            return output;
        }

        private async Task PowerBIClient()
        {
            if(_client == null)
            {
                var token = await _azureService.GetAccessToken();
                var tokenCredentials = new TokenCredentials(token, "Bearer");
                _client = new PowerBIClient(new Uri(_config.PowerBI.ApiUrl), tokenCredentials);
            }
        }

    }
}
