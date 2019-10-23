using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp
{
    class Packet
    {
        public DateTime TimeStamp { get; set; }
        public Queue<char> msg { get; set; }

        public Packet(DateTime t)
        {
            this.TimeStamp = t;
            this.msg = new Queue<char>();
        }

    }
}
