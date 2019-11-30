using DividendAlertBlazorPWA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DividendAlertBlazorPWA.Services
{
    public interface IDividendAlertService
    {
        Task<List<Dividend>> GetNewDividendsAsync(int days);
    }
}
