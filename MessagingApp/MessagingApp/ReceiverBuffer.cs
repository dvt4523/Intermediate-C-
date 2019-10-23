using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp
{
    class ReceiverBuffer
    {
        public string displayMsg;
        public DateTime TimeStamp;
        public Stack<char> receiver;

        public ReceiverBuffer(DateTime dt)
        {
            this.TimeStamp = dt;
            this.receiver = new Stack<char>();
        }       //Constructor
        
    }
    
}
