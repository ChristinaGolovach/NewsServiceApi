using System.Collections.Generic;
using System.Threading.Tasks;
using NewsServiceApi.DAL.Models;

namespace NewsServiceApi.DAL.Repositories
{
    public interface INewsRepository
    {
        Task<News> GetByIdAsync(int Id);
        Task<IEnumerable<News>> GetAllAsync();
       // Task<IEnumerable<News>> GetByCategoryAsync();
        Task CreateAsync(News news);
        Task UpdateAsync(News news);
        Task DeleteAsync(int Id);
    }
}
