using System;

namespace NewsServiceApi.DAL.Model
{
    public class News
    {
        public long Id { get; set; }
        public string Heading { get; set; }
        public string Body { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }        
        public int IdCategory { get; set; }
    }
}
