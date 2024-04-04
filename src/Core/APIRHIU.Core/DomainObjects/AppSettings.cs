using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRHIU.Core.DomainObjects
{
    public class AppSettings
    {
        public string? BaseAdress { get; set; } = null;
        public string? RessourceUrl { get; set; } = null;
        public string? PrivateKey { get; set; } = null;
    }
}
