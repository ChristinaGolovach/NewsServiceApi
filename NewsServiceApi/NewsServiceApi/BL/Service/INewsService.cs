using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsServiceApi.BL.DTO;

namespace NewsServiceApi.BL.Service
{
    public interface INewsService
    {
        Task<NewsDTO> GetByIdAsync(long id);
        Task<IEnumerable<NewsDTO>> GetAllNewsAsync();
        Task CreateNewsAsync(NewsDTO news);
    }
}
