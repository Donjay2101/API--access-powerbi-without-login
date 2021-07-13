using API.PowerBI.Models;
using API.PowerBI.Services.Abstract;
using API.PowerBI.Services.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.PowerBI.Extensions
{
    public static class DIExtension
    {
        public static void  AddDependencyInjection(this IServiceCollection services, IConfiguration Configuration)
        {
            var powerBIconfig = Configuration.GetSection("BaseConfig");
            services.Configure<BaseConfig>(powerBIconfig);

            services.AddSingleton<IPowerBIService, PowerBIService>();
            services.AddSingleton<IAzureService, AzureService>();
        }
    }
}
