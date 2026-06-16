

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntrePreneurServiceAPI.Models
{
        public class User
        {

         [BsonId]
         [BsonRepresentation(BsonType.ObjectId)]
         public string? Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public byte[] Img { get; set; }
            public string Contact { get; set; }
        public string Gender { get; set; }

            public string Profession { get; set; }

            public string HouseNo { get; set; }
            public string AddressLine1 { get; set; }
            public string DateofBirth { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Pincode { get; set; }
            public string About { get; set; }
        public string Education { get; set; }
        public string Work { get; set; }
        public string Email { get; set; }

        //public List<Product> Products { get; set;
    }
    }

