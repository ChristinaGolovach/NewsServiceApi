using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsServiceApi.BL.Service;
using NewsServiceApi.BL.DTO;
using NewsServiceApi.BL.Types;
using System.Linq;
using System;
using NewsServiceApi.BL.Types;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsServiceApi.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: api/news        
        [HttpGet]
        public async Task<IEnumerable<NewsDTO>> Get()
        {
            return await _newsService.GetAllNewsAsync();
        }

        // GET: api/news/{nameCategory} for instance  - api/news/Important        
         
        [HttpGet("{nameCategory}")]
        //[Route("[GetByCategory]")]
        //[RouteAttribute ("{nameCategory}")]
        public async Task<IEnumerable<NewsDTO>> GetByCategory(string nameCategory)
        {
            int idCategory = EnumExtention.GetValues<NewsCategoryTypes>().FirstOrDefault(e => e.Name == nameCategory).Value;  
            IEnumerable<NewsDTO> allNews = await _newsService.GetAllNewsAsync();
            return allNews.Where(news => news.IdCategory == idCategory);           
        }
        

        // GET: api/news/{id}
        [HttpGet("{id:int}")]
        public async Task<NewsDTO> GetById(long id)
        {
            return await _newsService.GetByIdAsync(id);
        }  
        
        [ProducesResponseType(201)]
        [HttpPost]
        public async Task AddNewsAsync([FromBody]NewsDTO news)
        {
            await _newsService.CreateNewsAsync(news);
        }
    }
}
