using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafitec.Cloud.Utils.Seguranca
{
    public abstract class Criptografia
    {
        public abstract string Criptografar(string str);
        public abstract string Decriptografar(string str);
    }
}
