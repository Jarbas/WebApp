using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rafitec.Cloud.Utils.Enums;

namespace Rafitec.Cloud.Portal.Web.Models
{
    public class Response
    {
        public StatusResponse Status { get; set; } = StatusResponse.Success;
        public string View { get; set; }
    }
}