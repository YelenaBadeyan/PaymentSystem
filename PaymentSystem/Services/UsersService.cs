using PaymentSystem.Data.DBContext;
using PaymentSystem.Data.Entities;
using PaymentSystem.Data.Models.RequestModels;
using PaymentSystem.Data.Models.ResponseModels;

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

        public List<Users> GetAllUsers() => dbContext.Users.ToList();

        public Users GetUserByID(int ID) => dbContext.Users.FirstOrDefault(n => n.ID ==ID);
         
        public Users UpdateUser(int ID, UsersRequestModel newUser)
        {

            var oldUser = dbContext.Users.First(n => n.ID == ID);
            oldUser.FirstName = newUser.FirstName;
            oldUser.LastName = newUser.LastName;
            oldUser.Email = newUser.Email;
            oldUser.SSN = newUser.SSN;
            oldUser.BirthDate = newUser.BirthDate;

            dbContext.SaveChanges();

           

            //dbContext.Users.Update(oldUser);
            return oldUser;

        }

        

    }

}
