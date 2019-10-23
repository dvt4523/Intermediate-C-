using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApp
{
    class SenderBuffer
    {
        public string SentMsg;
        public DateTime TimeStamp;
        public Stack<char> thisPacket;
        char[] sendArray;

        public SenderBuffer(string st)
        {
            this.SentMsg = st;
            this.TimeStamp = DateTime.Now;
            this.thisPacket = new Stack<char>();
        }               //Constructor

        public int PacketCounter()
        {
            int i = 0;
            i = SentMsg.Length / 50 + 1;
            return i;
        }                   //Return the amount of packets that the message will be splitted into.

        public void Loader()
        {
            this.sendArray = this.SentMsg.ToCharArray();
            for (int i = 0; i < sendArray.Length; i++)
            {
                this.thisPacket.Push(this.sendArray[i]);
            }
        }                         //Process the string message into stack of char.
    }
}
