using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsServiceApi.DAL.Repositories;
using NewsServiceApi.DAL.Repositories.Categories;
using NewsServiceApi.DAL.Models;
using NewsServiceApi.BL.DTO;
using AutoMapper;

namespace NewsServiceApi.BL.Service
{
    public class NewsService: INewsService
    {
        private readonly string _categoryByDefault="important";
        private readonly INewsRepository _newsRepository;
        private readonly ICategoryRepository _categoryRepository;
        private NewsCategoriesDTO _newsCategoriesDTO;


        public NewsService (INewsRepository newsRepository, ICategoryRepository categoryRepository)
        {
            _newsRepository = newsRepository;
            _categoryRepository = categoryRepository;
        }

        
        //TODO paging ???
        public async Task<IEnumerable<NewsDTO>> GetAllNewsAsync()
        {
            IEnumerable<News> news =await _newsRepository.GetAllAsync();
            return Mapper.Map<IEnumerable<News>, List<NewsDTO>>(news);
        }

        
        public async Task<NewsCategoriesDTO> GetAllNewsAndCategoriesAsync()
        {
            IEnumerable<News> news = await _newsRepository.GetAllByCategoryAsync(_categoryByDefault);
            IEnumerable<Category> categories = await _categoryRepository.GetAllCategoriesAsync();

            var categoriesDTO = Mapper.Map<IEnumerable<Category>, List<CategoriesDTO>>(categories);
            var newsDTO = Mapper.Map<IEnumerable<News>, List<NewsDTO>>(news);

            _newsCategoriesDTO = new NewsCategoriesDTO();
            _newsCategoriesDTO.Categories = categoriesDTO;
            _newsCategoriesDTO.News = newsDTO;

            return _newsCategoriesDTO;
        }

        public async Task<IEnumerable<NewsDTO>> GetByCategoryAsync(string nameCategory)
        {
            IEnumerable<News> news = await _newsRepository.GetAllByCategoryAsync(nameCategory);
            var newsDTO = Mapper.Map<IEnumerable<News>, List<NewsDTO>>(news);
            return newsDTO;
        }

        public async Task<NewsDTO> GetByIdAsync(int id)
        {
            News news =  await _newsRepository.GetByIdAsync(id);
            return Mapper.Map<News, NewsDTO>(news);
        }

        public async Task CreateNewsAsync(NewsDTO news)
        {
            News newNews = Mapper.Map<NewsDTO, News>(news);
            await _newsRepository.CreateAsync(newNews);
        }



    }
}
