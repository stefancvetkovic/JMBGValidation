using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMBGValidation
{
    public class JMBGInfo : JMBGObject
    {
        //public dynamic response = new CommandResponse();
        public char pol;
        public DateTime dRodjenja = new DateTime();
    }

    public class JMBGObject
    {
        public bool HasData { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
