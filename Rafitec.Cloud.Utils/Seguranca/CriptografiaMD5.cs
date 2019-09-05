using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rafitec.Cloud.Utils.Seguranca
{
    public class CriptografiaMD5 : Criptografia
    {
        public override string Criptografar(string str)
        {
            MD5 cryptoMd5 = MD5.Create();
            StringBuilder senhaStr = new StringBuilder();
            byte[] senhaCrypto = cryptoMd5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (var i = 0; i < senhaCrypto.Length; i++)
                senhaStr.Append(senhaCrypto[i].ToString());
            return senhaStr.ToString();
        }

        public override string Decriptografar(string str)
        {
            throw new NotImplementedException();
        }

    }
}
