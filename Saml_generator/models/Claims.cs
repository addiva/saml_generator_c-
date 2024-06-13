namespace Luxottica.Models
{
    public class Claims
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string CompanyCode { get; set; }
        public string UserID { get; set; }

        public Claims(string name, string surname, string email, string country, string companyCode, string userID)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Country = country;
            CompanyCode = companyCode;
            UserID = userID;
        }
    }
}
