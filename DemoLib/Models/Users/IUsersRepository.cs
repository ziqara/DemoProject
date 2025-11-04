using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLib.DataModel.Users;

namespace DemoLib.Models.Users
{
    public interface IUsersRepository
    {
        List<User> GetAllUsers();

        User GetUserByLogin(string login);
    }
}
