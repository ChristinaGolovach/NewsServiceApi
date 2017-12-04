using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsServiceApi.BL.Service;
using NewsServiceApi.BL.DTO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsServiceApi.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController (INewsService newsService)
        {
            _newsService = newsService;
        }

        // GET: api/news
        [HttpGet]
        public async Task <IEnumerable<NewsDTO>> Get()
        {
            return await _newsService.GetAllNewsAsync();
        }

        
    }
}
