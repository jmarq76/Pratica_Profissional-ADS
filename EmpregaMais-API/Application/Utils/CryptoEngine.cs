using System.Security.Cryptography;
using System.Text;

namespace Application.Utils
{
    public class CryptoEngine
    {
        public static string EncryptPlainTextToCypher(string text1, string text2)
        {
            var secuirtyKey = ConvertToHash(text1 + text2);

            var toEncryptedArray = Encoding.UTF8.GetBytes(text1);

            var objMD5CryptoService = MD5.Create();

            var securityKeyArray = objMD5CryptoService.ComputeHash(secuirtyKey);

            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = TripleDES.Create();
            objTripleDESCryptoService.Key = securityKeyArray;
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;


            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();

            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string DecryptCipherTextToPlainText(string text1, string text2, string cipherText)
        {
            var secuirtyKey = ConvertToHash(text1 + text2);

            byte[] toEncryptArray = Convert.FromBase64String(cipherText);
            var objMD5CryptoService = MD5.Create();

            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(secuirtyKey);
            objMD5CryptoService.Clear();

            var objTripleDESCryptoService = TripleDES.Create();
            objTripleDESCryptoService.Key = securityKeyArray;
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            objTripleDESCryptoService.Clear();

            return Encoding.UTF8.GetString(resultArray);
        }

        private static byte[] ConvertToHash(string textToHash)
        {
            var hash = new StringBuilder();
            var md5Provider = MD5.Create();

            return md5Provider.ComputeHash(Encoding.UTF8.GetBytes(textToHash));
        }
    }
}
