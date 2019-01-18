using MikroCrm.Common.CryptoServices;
using MikroCrm.Data.Domain.Entities;
using MikroCrm.Service;

namespace MikroCrm.Services.UserService
{
    public  class UserAppService:BaseService<UserApp>
    {
        public UserApp ValidetUser(string email,string password)
        {
            var user = _unit.Repository<UserApp>().Get(x => x.Email.Trim() == email.Trim() && x.Password == password && x.IsActive==true && x.Role.Name=="Admin");
            return user;
        }
    }
}
