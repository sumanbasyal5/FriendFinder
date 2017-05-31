using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Message
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Messages { get; set; }
        public bool Seen { get; set; }
        public System.DateTime SendDateTime { get; set; }
        public string SendReceive { get; set; }

    }
}
