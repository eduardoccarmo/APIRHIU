using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRHIU.Core.Message
{
    public abstract class Mensagem
    {
        public string MessageType { get; protected set; }

        protected Mensagem()
        {
            MessageType = GetType().Name;
        }
    }
}
