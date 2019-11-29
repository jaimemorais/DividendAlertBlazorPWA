using DividendAlertBlazorPWA.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DividendAlertBlazorPWA.Data
{
    public interface IDividendAlertService
    {
        Task<IEnumerable<Dividend>> GetNewDividendsAsync();
    }
}
