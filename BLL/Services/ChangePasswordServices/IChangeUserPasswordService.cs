using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.BLL.Services.ChangePasswordServices;

public interface IChangeUserPasswordService
{
    bool ChangePassword(Guid userId, string newPassword, string oldPassword);
}
