using PaymentSystem.Data.DBContext;
using PaymentSystem.Data.Entities;
using PaymentSystem.Data.Models.RequestModels;

namespace PaymentSystem.Services
{
    public class UsersService
    {
        private AppDBContext dbContext;

        public UsersService(AppDBContext context)
        {
            dbContext = context;
        }


        public void AddUser(UsersRequestModel user)
        {
            var newUser = new Users()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                BirthDate = user.BirthDate,
                Phone = user.Phone,
                SSN = user.SSN,
            };

            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
        }
    }

}
