using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace DeCommunicator
{
    class TalkieServer
    {
        //8888 PORT 

        //initiate basic stuff to the server? 
        //Should it be a static class? (will initiate this class only once)
        public TalkieServer()
        {
        }

        public void BuildServer()
        {
            TcpListener serverSocket = new TcpListener(8888);//deprecated binding to some port
            int requestCount; //?

            TcpClient clientSocket = default(TcpClient); //WHY do you need to create a client socket in the server
            serverSocket.Start();


            Console.WriteLine(" >> Server Started");

            clientSocket = serverSocket.AcceptTcpClient();// Accept the data of the socket ()

            Console.WriteLine(" >> Accept connection from client");
            requestCount = 0;



            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;//count the requests - every time it enters the loop -its a new request

                    //create network stream --- Get the Stream From Client
                    NetworkStream networkStream = clientSocket.GetStream();

                    byte[] bytesFrom = new byte[10025];

                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);//read

                    string dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));


                    Console.WriteLine(" >> Data from client - " + dataFromClient);
                    string serverResponse = "Last Message from client" + dataFromClient;


                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();

                    Console.WriteLine(" >> " + serverResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            clientSocket.Close(); //why unreacheble??
            serverSocket.Stop();
            Console.WriteLine(" >> exit");
            Console.ReadLine();

        }

    

    }
}
