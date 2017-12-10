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
    [Route("api/news")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: api/news        
        [HttpGet]        
        public async Task<IActionResult> AllNewsAsync()
        {
            var allNews = await _newsService.GetAllNewsAsync();
            if (allNews == null)
                return NotFound();
            return Ok(allNews);
        }

        // GET: api/news/{nameCategory}     
        [HttpGet("{nameCategory}")]
        public async Task<IEnumerable<NewsDTO>> GetByCategory(string nameCategory)
        {
            int idCategory = EnumExtention.GetValues<NewsCategoryTypes>().FirstOrDefault(e => e.Name == nameCategory).Value;  
            IEnumerable<NewsDTO> allNews = await _newsService.GetAllNewsAsync();
            return allNews.Where(news => news.IdCategory == idCategory);           
        }

        // GET: api/news/{category}/{id}
        [HttpGet]
        [Route("{category}/{id:int}")]
        public async Task<NewsDTO> GetById(string category, int id)
        {
            return await _newsService.GetByIdAsync(id);
        }

        // GET: api/news/{id}
        [HttpGet("{id:int}")]
        public async Task<NewsDTO> GetById(int id)
        {
            return await _newsService.GetByIdAsync(id);
        }
               
        [HttpPost]
        public async Task AddNewsAsync([FromBody]NewsDTO news)
        {
            await _newsService.CreateNewsAsync(news);
        }
    }
}
