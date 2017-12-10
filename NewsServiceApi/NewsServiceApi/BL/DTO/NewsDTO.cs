using System;
using System.ComponentModel.DataAnnotations;

namespace NewsServiceApi.BL.DTO
{
    public class NewsDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter News heading")]
        [StringLength(200, ErrorMessage ="The heading of news can not excced 200 characters")]
        public string Heading { get; set; }

        [Required(ErrorMessage = "Please enter News text")]
        [StringLength(2000, ErrorMessage = "The text of news can not excced 2000 characters")]
        public string Body { get; set; }

        public DateTime Date { get; set; }

        [Required(ErrorMessage ="Please select News category")]
        public int IdCategory { get; set; }      
    }
}
