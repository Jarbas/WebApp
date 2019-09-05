using Rafitec.Cloud.Utils.Anotacao;
using System;

namespace Rafitec.Cloud.Utils.ClassExtensions
{
    public static class StringExtensions
    {
        public static T ParseToEnum<T>(this string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    var enumAtual = typeof(T);
                    var enumFields = enumAtual.GetFields();
                    foreach (var propertyAtual in enumFields)
                    {
                        var anotatiion = propertyAtual.GetCustomAttributes(typeof(IsDefaultEnumValue), false);
                        if (anotatiion != null && anotatiion.Length > 0)
                            return (T)Enum.Parse(typeof(T), propertyAtual.Name, true);
                    }
                }

                return (T)Enum.Parse(typeof(T), value, true);
            }catch(Exception e)
            {
                throw new Exception($"Erro na conversão de enum {typeof(T).FullName}. Erro ===>{e.ToString()}");
            }
      
        }
    }
}
