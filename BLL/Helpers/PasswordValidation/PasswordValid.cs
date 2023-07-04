using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers.PasswordValidation;

public class PasswordValid
{
    public static bool IsValidatePassword(string password)
    {
        if (password.Length < 8) return false;

        if (!password.Any(char.IsUpper) || !password.Any(char.IsLower)) return false;

        if (!password.Any(char.IsDigit)) return false;

        return true;
    }
}
