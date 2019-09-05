using Rafitec.Cloud.Portal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rafitec.Cloud.Portal.Web.HtmlHelpers
{
    public static class FilterDefaultHelpers
    {

          public static string ToQueryString(this object request, string separator = "&") 
          {
              if (request == null)
                  return String.Empty;
              
              var properties = request.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(request, null));
              var urlParam = string.Empty;

              foreach (var prop in properties)
                  if (!(prop.Value == null || prop.Value.ToString() == "None"))
                      urlParam += $"{prop.Key}={prop.Value.ToString()}{separator}";

              if (string.IsNullOrEmpty(urlParam))
                  return string.Empty;
              else
                return  $"{urlParam.Substring(0, (urlParam.Length -1))}";
          }
    }
}