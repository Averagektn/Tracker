using System.Net;
using System.Net.Sockets;

namespace NewTracker.Network
{
    /// <summary>
    /// Represents a TCP receiver that listens for incoming connections and receives data.
    /// </summary>
    internal class TCPReceiver
    {
        private static List<int[]> arrays = new();
        private static List<TcpClient> clients = new();
        private static bool isRunning = false;
        /// <summary>
        /// Starts the TCP receiver.
        /// </summary>
        public static void Start()
        {
            int port = 12345;
            var listener = new TcpListener(IPAddress.Any, port);

            isRunning = true;

            listener.Start();

            while (isRunning)
            {
                if (listener.Pending())
                {
                    TcpClient client = listener.AcceptTcpClient();

                    clients.Add(client);

                    var clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();
                }
            }

            listener.Stop();
        }

        private static void HandleClient(TcpClient client)
        {
            try
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[3 * sizeof(int)];

                while (isRunning)
                {
                    if (stream.DataAvailable)
                    {
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);

                        int[] numbers = new int[3];
                        Buffer.BlockCopy(buffer, 0, numbers, 0, buffer.Length);

                        arrays.Add(numbers);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Gets the next target array received from the TCP connection.
        /// </summary>
        /// <returns>An array representing the target.</returns>
        public static int[] GetNewTarget()
        {
            int[] res = Array.Empty<int>();
            if (isRunning && arrays.Count != 0)
            {
                res = arrays[0];
                arrays.RemoveAt(0);
                return res;
            }
            return res;
        }

        /// <summary>
        /// Stops the TCP receiver and sends the remaining targets to the connected clients.
        /// </summary>
        /// <param name="logFile">The path to the log file.</param>
        /// <param name="x_center">The X-coordinate of the center.</param>
        /// <param name="y_center">The Y-coordinate of the center.</param>
        public static void Stop(string logFile, int x_center, int y_center)
        {
            using var sr = new StreamReader(logFile);
            string? str;
            isRunning = false;

            while ((str = sr.ReadLine()) != null)
            {
                string[] numbers = str.Split(' ');
                int num1 = 0, num2 = 0;
                if (numbers.Length == 2 && int.TryParse(numbers[0], out num1) && int.TryParse(numbers[1], out num2))
                {
                    foreach (TcpClient client in clients)
                    {
                        try
                        {
                            NetworkStream stream = client.GetStream();

                            byte[] sendBytes = new byte[2 * sizeof(int)];
                            Buffer.BlockCopy(BitConverter.GetBytes(num1), 0, sendBytes, 0, 4);
                            Buffer.BlockCopy(BitConverter.GetBytes(num2), 0, sendBytes, 4, 4);

                            stream.Write(sendBytes, 0, sendBytes.Length);
                        }
                        catch
                        {
                        }
                    }
                }
            }

            foreach (TcpClient client in clients)
            {
                client.Close();
                client.Dispose();
            }
            clients.Clear();
        }
    }
}
