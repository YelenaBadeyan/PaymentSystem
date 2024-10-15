namespace PaymentSystem.Data.Models.RequestModels
{
    public class UsersRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
    }
}
