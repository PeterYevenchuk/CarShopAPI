using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace BLL.Helpers.PasswordHasher;

public class PasswordHash : IPasswordHash
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 10000;

    public string EncryptPassword(string password, byte[] salt)
    {
        byte[] byteArray = { 3, 9, 1 };
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: byteArray,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 1000000,
            numBytesRequested: 256 / 8));
    }
}
