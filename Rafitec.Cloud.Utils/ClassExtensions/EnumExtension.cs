using System;
using System.Reflection;

namespace Rafitec.Cloud.Utils.ClassExtensions
{
    public class EnumDescricao : Attribute
    {
        private string Text;



        public EnumDescricao(string text)
        {
            Text = text;
        }


        public static string Get(Enum _enum)
        {
            Type type = _enum.GetType();
            MemberInfo[] memberInfo = type.GetMember(_enum.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attributes = memberInfo[0].GetCustomAttributes(typeof(EnumDescricao), false);

                if (attributes != null && attributes.Length > 0)
                    return ((EnumDescricao)attributes[0]).Text;

            }
            return _enum.ToString();
        }


    }
}
