using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsServiceApi.BL.DTO;

namespace NewsServiceApi.BL.Service
{
    public interface INewsService
    {
        Task<NewsDTO> GetByIdAsync(int id);
        Task<IEnumerable<NewsDTO>> GetAllNewsAsync();
        Task<NewsCategoriesDTO> GetAllNewsAndCategoriesAsync();
        Task<IEnumerable<NewsDTO>> GetByCategoryAsync(string nameCaregory);
        Task CreateNewsAsync(NewsDTO news);
    }
}
