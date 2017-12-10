using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsServiceApi.BL.DTO
{
    public class NewsCategoriesDTO
    {
        public IEnumerable<NewsDTO> News { get; set; }
        public IEnumerable<CategoriesDTO> Categories { get; set; }
    }
}
