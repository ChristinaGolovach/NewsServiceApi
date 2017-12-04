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
        //TODO paging ???
        public async Task<IEnumerable<NewsDTO>> GetAllNewsAsync()
        {
            IEnumerable<News> news =await _newsRepository.GetAllAsync();
            return AutoMapper.Mapper.Map<IEnumerable<News>, List<NewsDTO>>(news);
        }

        //TODO: can I use lambda expression instead recall ?
        public async Task<NewsDTO> GetByIdAsync(long id)
        {
            News news =  await _newsRepository.GetByIdAsync(id);
            return AutoMapper.Mapper.Map<News, NewsDTO>(news);
        }



    }
}
