using System;

namespace NewsServiceApi.DAL.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Body { get; set; }
        public DateTime? Date { get; set; }     
        public int IdCategory { get; set; }
    }
}
