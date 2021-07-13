using API.PowerBI.Models;
using System.Threading.Tasks;

namespace API.PowerBI.Services.Abstract
{
    public interface IPowerBIService
    {
        Task<ReportOutput> GetReport(ReportInput reportInput);
    }
}
