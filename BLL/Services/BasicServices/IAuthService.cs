using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.BLL.Services.BasicServices;

public interface IAuthService
{
    string AuthenticateUser(string login, string password);
}
