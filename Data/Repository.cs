using Microsoft.EntityFrameworkCore;
using SindaCMS.Models;

namespace SindaCMS.Data
{
    public class Repository: IRepository
    {
        private readonly DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }

        public async Task<Site> GetSiteAsync() => await _db.Sites.Include(s => s.PageNames.OrderBy(d => d.Index)).FirstAsync();

        public async Task<List<Tab>> GetPageTabsAsync(string pageName) => await _db.Tabs
            .Where(t => t.PageName == pageName)
            .OrderBy(t => t.Index)
            .Include(t => t.Sections.OrderBy(s => s.Index))
            .ThenInclude( s=> s.Details)
            .ThenInclude( d => d.Contents)
            .ToListAsync();
    }
}
