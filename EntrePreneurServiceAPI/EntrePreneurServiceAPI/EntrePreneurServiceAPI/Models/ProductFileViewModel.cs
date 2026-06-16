namespace EntrePreneurServiceAPI.Models
{
    public class ProductFileViewModel
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Stage { get; set; }
        public string Owners { get; set; }
        public string SharePrice { get; set; }
        public string BusinessModel { get; set; }
        public string Description { get; set; }
       // public DateTime Date { get; set; } = DateTime.Now;
       
        public IFormFile ImageFile { get; set; }
       public IFormFile PdfFile { get; set; }
        // public List<IFormFile> Files { get; set; }
        public string Email { get; set; }
    }
}
