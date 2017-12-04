using System.Collections.Generic;
using System.Threading.Tasks;
using NewsServiceApi.DAL.Model;

namespace NewsServiceApi.DAL.Repositories
{
    interface INewsRepository
    {
        Task<News> GetByIdAsync(long Id);
        Task<IEnumerable<News>> GetAllAsync();
        Task CreateAsync(News news);
        Task UpdateAsync(News news);
        Task DeleteAsync(long Id);
    }
}
