namespace EntrePreneurServiceAPI.Models
{
    public class ProductReturnData
    {
        public string Title { get; set; }
        //public string ImageBase64 { get; set; }
        //public string PdfBase64 { get; set; }
        public string ProductId { get; set; }
        // public string Title { get; set; }

        //public byte[] ImageFile { get; set; }
        // public byte[] PdfFile { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Stage { get; set; }
        //  public string Owners { get; set; }
        // public string SharePrice { get; set; }
        public string BusinessModel { get; set; }
        // public string Description { get; set; }
        // public DateTime Date { get; set; } = DateTime.Now;
    }
}
