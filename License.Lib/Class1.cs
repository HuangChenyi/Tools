using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace License.Lib
{
    public class Valid
    {
        /// <summary>
        /// RSA 解密
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="crText"></param>
        /// <returns></returns>
        private string RSADecrypt(string crText, string privateKey = "")
        {
            RSACryptoServiceProvider.UseMachineKeyStore = true;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] ctTextArray = Convert.FromBase64String(crText);
            byte[] base64PrivateKey = Convert.FromBase64String(privateKey);
            rsa.FromXmlString(Encoding.UTF8.GetString(base64PrivateKey));

            byte[] decodeBs = rsa.Decrypt(ctTextArray, false);

            return Encoding.UTF8.GetString(decodeBs);
        }
    }
}
