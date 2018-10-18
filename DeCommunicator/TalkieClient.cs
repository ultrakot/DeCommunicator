using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;


namespace DeCommunicator
{
    class TalkieClient
    {
        //we're talking trough 8888 port on the computer

        string TextMessage;
        TcpClient clientSocket = new TcpClient();

        public TalkieClient()
        {
            TextMessage = "ALL YOUR BASE BELONG TO US!!1";
        }


        public void BuildClient()
        {
            Console.WriteLine("Client Started"); // TODO: move to Debugger.WriteLine();
            clientSocket.Connect("127.0.0.1", 8888);
            Console.WriteLine("Client Socket Program - Server Connected ...");
        }


        //True / False - depending on wheter the message was sent
        //כול מה שזה עושה זה להעביר מידע לביית ולשלוח 
        //להחזיר מידע מביית לכתב
        public bool SendMessage()
        {

            //is there a reason for try catch?

            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = Encoding.ASCII.GetBytes(TextMessage + "$");//  Encodes FROM ASCII -> Bytes


                               //buffer   /offstream  /size
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush(); //EH? leave the stream empty?


            byte[] inStream = new byte[10025]; //creates a new Array of Bytes


            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);//read to inStream, get the buffer size from Client Socket
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);//From bytes --> ASCII

            //*******************************************
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("the Message is ! : " + returndata);

            Console.ResetColor();
            //******************************************

            return true;
        }
     

  
    }
}
