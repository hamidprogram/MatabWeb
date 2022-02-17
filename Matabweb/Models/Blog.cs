namespace Matabweb.Models
{
    public class Blog
    {
        public int ID { get; set; }
        public string NameBlgo { get; set; }
        public string ShortExp { get; set; }
        public string Text { get; set; }
        public IFormFile Photo { get; set; }
        public string Tags { get; set; }
    }
}
