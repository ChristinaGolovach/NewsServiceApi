using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsServiceApi.DAL.Repositories;
using NewsServiceApi.DAL.Model;
using NewsServiceApi.BL.DTO;

namespace NewsServiceApi.BL.Service
{
    public class NewsService: INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService (INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<IEnumerable<NewsDTO>> GetAllNewsAsync()
        {
            IEnumerable<News> news =await _newsRepository.GetAllAsync();
            return AutoMapper.Mapper.Map<IEnumerable<News>, List<NewsDTO>>(news);
        }
    }
}
