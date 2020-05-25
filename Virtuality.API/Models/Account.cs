namespace Virtuality.API.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Bank { get; set; }

        public string AccountHolderName { get; set; }

        public string AccountNumber { get; set; }

        public string IFSC { get; set; }
    }
}