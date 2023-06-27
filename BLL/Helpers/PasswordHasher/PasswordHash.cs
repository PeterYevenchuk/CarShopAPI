using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace BLL.Helpers.PasswordHasher;

public class PasswordHash : IPasswordHash
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 10000;

    public string EncryptPassword(string password)
    {
        // Random salt generation
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Password hash generation
        byte[] hash = KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: Iterations,
            numBytesRequested: HashSize
        );

        byte[] hashWithSalt = new byte[SaltSize + HashSize];
        Buffer.BlockCopy(salt, 0, hashWithSalt, 0, SaltSize);
        Buffer.BlockCopy(hash, 0, hashWithSalt, SaltSize, HashSize);

        return Convert.ToBase64String(hashWithSalt);
    }
}
