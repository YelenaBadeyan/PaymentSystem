using MediatR;

namespace PaymentSystem.Queries.UserQueries
{
    public class UpdateUserQuery : IRequest<int>
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
