using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MessagingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type your message here:");
            SenderBuffer currentMessage = new SenderBuffer(Console.ReadLine());
            int n = currentMessage.PacketCounter();
            Console.WriteLine("------------------------Transport process------------------------");
            Console.WriteLine($"\nThis message will be splitted into {n} packet(s)");
            currentMessage.Loader();
            Packet[] packets = new Packet[n];
     #region Load message to packets
            for (int i = 0; i < n; i++)
            {
                packets[i] = new Packet(currentMessage.TimeStamp);
                try
                {
                    for (int j = 0; j < 50; j++)
                    {
                        packets[i].msg.Enqueue(currentMessage.thisPacket.Pop());
                    }
                }
                catch
                {
                    for (int j = 0; j < currentMessage.thisPacket.Count; j++)
                    {
                        packets[i].msg.Enqueue(currentMessage.thisPacket.Pop());
                    }
                }
                Console.WriteLine($"\n Packet {i+1} consists of:");
                foreach (char character in packets[i].msg)
                {
                    Console.Write(character);
                }           // Display the packets
            }
     #endregion

     #region Unload message from packets to receiver
            ReceiverBuffer receivedMessage = new ReceiverBuffer(packets[0].TimeStamp);
            for (int i = 0; i < n; i++)
            {
                try
                {
                    for (int j = 0; j < 50; j++)
                    {
                        receivedMessage.receiver.Push(packets[i].msg.Dequeue());
                    }
                }

                catch
                {
                    for (int j = 0; j < currentMessage.thisPacket.Count; j++)
                    {
                        receivedMessage.receiver.Push(packets[i].msg.Dequeue());
                    }
                }
            }
            receivedMessage.displayMsg = new string(receivedMessage.receiver.ToArray());
     #endregion
            Console.WriteLine("\n----------------------End Transport process----------------------");
            Console.WriteLine("\nThe received message is:");
            Console.WriteLine($"{receivedMessage.TimeStamp.ToString()}: {receivedMessage.displayMsg}");
            Console.ReadLine();
        }
    }
}