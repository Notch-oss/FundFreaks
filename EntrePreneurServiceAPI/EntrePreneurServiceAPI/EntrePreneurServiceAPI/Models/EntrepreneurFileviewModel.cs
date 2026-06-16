namespace EntrePreneurServiceAPI.Models
{
    public class EntrepreneurFileviewModel
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // public byte[] Img { get; set; }
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
        public IFormFile Img { get; set; }
        public string Email { get; set; }
    }
}
