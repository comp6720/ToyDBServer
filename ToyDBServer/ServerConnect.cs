using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerConnect
{
    class Server
    {
        // Create a listener object to store data coming from client
        public Socket Listener { get; set; }

        // Create a socket object
        public Socket ClientSocket { get; set; }

        /**
         * Connects to the client on the specified port.
         * Displays data sent from client.
         * 
         * @return void
        */
        public void ExecuteServer()
        {
            //Create a socket to establish connection to client
            ConnectSocket(11111);

            while (true)
            {
                Console.WriteLine("Awaiting connection from client ... ");

                // Suspend while waiting for incoming connection Using Accept()
                ClientSocket = Listener.Accept();

                //Display connected status message
                Console.WriteLine("Connected\n");

                //Proceed to the rest of the program once connection has been established
                break;
            }
        }


        /**
         * Sends the results of the query back to the client.
         * The result is encoded as a byte and sent through the socket to the connected server port.
         * 
         * @param String result - the result to be sent to client
         * 
         * @return void
        **/
        public void SendResults(string result)
        {
            try
            {
                byte[] message = Encoding.ASCII.GetBytes(result);
                ClientSocket.Send(message);
            }

            // Management of Socket's Exceptions 
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }

            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }

            catch (ObjectDisposedException ode)
            {
                Console.WriteLine("ObjectDisposedException : {0}", ode.ToString());
            }

            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }


        /**
         * Receive query from the client.
         * Create a byte object to store data coming from client.
         * The data coming from the client will be in bytes.
         * The data in bytes is then be converted back to a string.
         * 
         * @return void
        */
        public void ReceiveQuery()
        {
            try
            {
                byte[] queryMessage = new Byte[1024];
                int byteRecv = ClientSocket.Receive(queryMessage);
                string data = Encoding.ASCII.GetString(queryMessage, 0, byteRecv);

                //Output message from client in the console
                Console.WriteLine("Query received -> {0} ", data);
            }

            // Management of Socket's Exceptions 
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }

            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }

            catch (ObjectDisposedException ode)
            {
                Console.WriteLine("ObjectDisposedException : {0}", ode.ToString());
            }

            catch (System.Security.SecurityException ssse)
            {
                Console.WriteLine("SecurityException : {0}", ssse.ToString());
            }

            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }


        /**
         * Open a socket to connect client to server on the specified port
         * 
         * @param int port - the port to connect to
         * 
         * @return void
        */
        public void ConnectSocket(int port)
        {
            // Establish the local endpoint for the socket. 
            // Dns.GetHostName returns the name of the host running the application. 
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);

            // Creation TCP/IP Socket using Socket Class Costructor 
            Listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Using Bind() method we associate a network address to the Server Socket 
                Listener.Bind(localEndPoint);

                // Using Listen() method we create the Client list that will connect to Server 
                Listener.Listen(10);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        /**
         * Close the socket and end the connection
         * After closing, the closed Socket can be used for a new Client Connection 
         * 
         * @return void
        **/
        public void CloseSocket()
        {
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
        }
    }
}