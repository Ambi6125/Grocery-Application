using System;
using EasyTools.PasswordEncryptionTools;
using System.Text;


namespace SynthesisEntities.Passwords
{
    public delegate string HashAlgorithm(string salt, string password);

    public static class PasswordHelper
    {
        public static HashAlgorithm DefaultHash => SHA512;
        public static string SHA512(string salt, string password)
        {
            var hasher = new SHA512Generator();
            return hasher.IEncrypt(password, salt);
        }

        public static string GenerateSalt(int length)
        {
            char[] possibleChars = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()_+-={}[],.<>?/|".ToCharArray();
            StringBuilder sb = new StringBuilder();
            Random letterSelector = new Random();
            for (int i = 0; i < length; i++)
            {
                int selection = letterSelector.Next(possibleChars.Length);
                sb.Append(possibleChars[selection]);
            }
            return sb.ToString();
        }
    }
}