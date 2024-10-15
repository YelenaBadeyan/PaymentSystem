using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSystem.Data.DBContext;
using PaymentSystem.Data.Models.RequestModels;
using PaymentSystem.Data.Models.ResponseModels;
using PaymentSystem.Services;

namespace PaymentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersService _usersService;

        public UsersController( UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("add_user")]

        public UsersResponseModel AddNewUser([FromBody]UsersRequestModel requestModel)
        {
            _usersService.AddUser(requestModel);
            return new UsersResponseModel()
            {
                BirthDate = requestModel.BirthDate,
                Email = requestModel.Email,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Phone = requestModel.Phone,
                SSN = requestModel.SSN
                
            };
        }


    }
}
