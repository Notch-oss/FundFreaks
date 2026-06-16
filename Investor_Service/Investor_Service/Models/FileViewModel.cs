namespace Investor_Service.Models
{
    public class FileViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Contact { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string DateofBirth { get; set; }
        public string Gender { get; set; }
        //public byte[] Content { get; set; }

        public string Houseno { get; set; }
        public string Streetno { get; set; }

        public string Education { get; set; }
        public string About { get; set; }
        public string work { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Stage { get; set; }
        public string Model { get; set; }
        public IFormFile File { get; set; }
        public string Email { get; set; }
        //public List<IFormFile> Files { get; set; }
    }
}
