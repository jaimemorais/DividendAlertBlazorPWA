using System.Threading.Tasks;

namespace DividendAlertBlazorPWA.Data
{
    public interface IDividendAlertService
    {
        Task<string> GetNewDividendsHtmlAsync();
    }
}
