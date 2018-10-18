using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeCommunicator
{
    class Program
    {
        static void Main(string[] args)
        {
            var flag = InitialState.server;

            Console.WriteLine("What is the aim of your program? /n");
            var userInput = Console.ReadLine().ToString();
            if (userInput == "s")
            {
                flag = InitialState.server;
            }
            else if (userInput == "c")
            {
                flag = InitialState.client;
            }

            //changes between client and a server like a carousel

            switch (flag)
            {
                case InitialState.client:


                    TalkieClient tryIt = new TalkieClient();
                    tryIt.BuildClient();
                    //behave like a client - SEND to some port

                    break;
                case InitialState.server:

                    TalkieServer tryMe = new TalkieServer();
                    tryMe.BuildServer();



                    //behave like a server - start listening to some port

                    break;
                default:
                    break;
            }

        }

        enum InitialState
        {
            client = 1,
            server = 2
        }
    }
}
