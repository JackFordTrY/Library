using Library.Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Library.Infrastructure.Services;

public class PasswordEncryptionService : IPasswordEncryption
{
    public string Encrypt(string password)
    {
        var sha256 = SHA256.Create();

        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

        var sb = new StringBuilder();

        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        }
        return sb.ToString();
    }
}
