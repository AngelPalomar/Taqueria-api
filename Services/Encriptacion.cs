using System.Security.Cryptography;
using System.Text;

namespace Taqueria.Services
{
    public static class Encriptacion
    {
        public static string EncriptarBase64(string dato)
        {
            string encriptarDato = string.Empty;
            var byteArray = Encoding.UTF8.GetBytes(dato);
            encriptarDato = Convert.ToBase64String(byteArray, Base64FormattingOptions.None);

            return encriptarDato;
        }

        public static string EncriptarSHA256(string dato)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(dato));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string EncriptarMD5(string dato)
        {
            MD5 md5 = MD5.Create();

            md5.ComputeHash(Encoding.ASCII.GetBytes(dato));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
