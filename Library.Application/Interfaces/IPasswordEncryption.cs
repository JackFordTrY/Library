namespace Library.Application.Interfaces;

public interface IPasswordEncryption
{
    string Encrypt(string password);
}
