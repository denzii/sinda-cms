using SindaCMS.Models;

namespace SindaCMS.Data
{
    public interface IRepository
    {
        Task<Site> GetSiteAsync();
        Task<List<Tab>> GetPageTabsAsync(string pageName);
    }
}