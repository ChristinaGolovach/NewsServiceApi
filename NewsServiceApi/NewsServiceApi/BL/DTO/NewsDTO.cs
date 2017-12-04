using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsServiceApi.BL.DTO
{
    public class NewsDTO
    {
        public long Id { get; set; }
        public string Heading { get; set; }
        public string Body { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int IdCategory { get; set; }
    }
}
