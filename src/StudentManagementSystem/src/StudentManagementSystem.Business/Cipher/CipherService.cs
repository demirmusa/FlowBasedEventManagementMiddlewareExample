using StudentManagementSystem.BLL.Cipher.Interfaces;
using System;
namespace StudentManagementSystem.BLL.Cipher
{
    /// <summary>
    /// they return text because its an example
    /// </summary>
    public class CipherService : ICipherService
    {
        public string Decrypt(string cipherText)
        {
            return cipherText;
        }
        public string Encrypt(string text)
        {
            return text;
        }
    }
}
