using System.Threading.Tasks;

namespace API.PowerBI.Services.Abstract
{
    public interface IAzureService
    {
        Task<string> GetAccessToken();
    }
}
