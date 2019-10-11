using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GrowthDiary.Wx
{
    public class SignatureModel
    {
        public string Signature { get; set; }

        public string Timestamp { get; set; }

        public string Nonce { get; set; }

        public string Echostr { get; set; }

        public string Openid { get; set; }



        public string Token { get; set; }

        public string EncodingAESKey { get; set; }
    }

    public static class SignatureHelper
    {
        public static bool Check(SignatureModel signatureModel)
        {
            List<string> temp = new List<string>() { signatureModel.Timestamp, signatureModel.Nonce, signatureModel.Token };
            temp.Sort();

            string str = "";
            foreach (string item in temp)
            {
                str += item;
            }
            SHA1 sha = new SHA1CryptoServiceProvider();

            var _byte = sha.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sha1Str = new StringBuilder();
            foreach (byte b in _byte)
            {
                sha1Str.AppendFormat("{0:x2}", b);
            }
            return sha1Str.ToString().Equals(signatureModel.Signature);
        }
    }
}
