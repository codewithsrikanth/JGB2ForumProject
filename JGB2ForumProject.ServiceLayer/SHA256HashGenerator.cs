using System.Security.Cryptography;
using System.Text;

namespace JGB2ForumProject.ServiceLayer
{
    public class SHA256HashGenerator
    {
        public static string GenerateHash(string inputData)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputData));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
