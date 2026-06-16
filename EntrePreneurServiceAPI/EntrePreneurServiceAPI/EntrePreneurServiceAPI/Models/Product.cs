using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace EntrePreneurServiceAPI.Models
{
    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string Title { get; set; }

        public byte[] ImageFile { get; set; }
       public byte[] PdfFile { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Stage { get; set; }
        public string Owners { get; set; }
        public string SharePrice { get; set; }
        public string BusinessModel { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Email { get; set; }
        

    }
}
