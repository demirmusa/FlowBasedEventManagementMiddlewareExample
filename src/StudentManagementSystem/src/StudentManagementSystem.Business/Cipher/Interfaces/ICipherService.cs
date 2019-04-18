using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.BLL.Cipher.Interfaces
{
    public interface ICipherService
    {
        string Encrypt(string text);
        string Decrypt(string cipherText);
    }
}
