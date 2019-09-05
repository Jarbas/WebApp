using System.Collections.Generic;
using Rafitec.Cloud.Utils.Enums;

namespace Rafitec.Cloud.Portal.Web.Models
{
    public class ResponseModelView
    {
        public StatusResponse Status { get; set; } = StatusResponse.Success;
        public IList<string> SuccessMessage { get; set; } = new List<string>();
        public string RotaSuccess { get; set; }
        public IList<string> ErrorMessage { get; set; } = new List<string>();
        public bool NovoCadastro { get; set; } = false;
        public string RotaNovoCadastro { get; set; }


        public void SetWarring(string msg)
        {
            Status = StatusResponse.Warning;
            ErrorMessage.Add(msg);
        }

        public void SetSussess(string msg)
        {
            Status = StatusResponse.Success;
            SuccessMessage.Add(msg);
        }

        public bool IsResponseValido()
        {
            return Status == StatusResponse.Success;
        }

    }
}