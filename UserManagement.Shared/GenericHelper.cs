using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Shared
{
    public class GenericHelper
    {
        public string GenerateRandomString(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be a positive integer.", nameof(length));

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var result = new StringBuilder(length);
            byte[] randomBytes = new byte[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            foreach (var b in randomBytes)
            {
                result.Append(chars[b % chars.Length]);
            }

            return result.ToString();
        }

        public string Generate6DigitRandomNumber()
        {
            return GenerateFixedLengthNumber(6);
        }


        private string GenerateFixedLengthNumber(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Length must be a positive integer.", nameof(length));

            var result = new StringBuilder(length);
            byte[] randomBytes = new byte[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            foreach (var b in randomBytes)
            {
                result.Append((b % 10).ToString());
            }

            return result.ToString();
        }
    }
}
