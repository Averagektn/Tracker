using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NewTracker.Network
{
    /// <summary>
    /// Represents a UDP receiver that listens for incoming datagrams and receives data.
    /// </summary>
    internal static class UDPReceiver
    {
        private static bool IsOn = false;
        private static List<int[]> arrays = new();
        /// <summary>
        /// Gets the next target array received from the UDP connection.
        /// </summary>
        /// <returns>An array representing the target.</returns>
        public static int[] GetNewTarget()
        {
            int[] res = Array.Empty<int>();
            if (IsOn && arrays.Count != 0)
            {
                res = arrays[0];
                arrays.RemoveAt(0);
                return res;
            }
            return res;
        }

        /// <summary>
        /// Stops the UDP receiver.
        /// </summary>
        public static void Stop()
        {
            arrays.Clear();
            IsOn = false;
        }

        /// <summary>
        /// Starts the UDP receiver.
        /// </summary>
        public static void Start()
        {
            int port = 12345;
            var udpServer = new UdpClient(port);
            var clientEndpoint = new IPEndPoint(IPAddress.Any, port);

            arrays = new();
            IsOn = true;

            try
            {
                while (IsOn)
                {
                    if (udpServer.Available >= 3 * sizeof(int))
                    {
                        byte[] receiveBytes = udpServer.Receive(ref clientEndpoint);

                        int[] numbers = new int[receiveBytes.Length / sizeof(int)];
                        Buffer.BlockCopy(receiveBytes, 0, numbers, 0, receiveBytes.Length);

                        int remainingNumbers = numbers.Length;
                        int currentIndex = 0;

                        while (remainingNumbers >= 3)
                        {
                            int[] array = new int[3];
                            Array.Copy(numbers, currentIndex, array, 0, 3);
                            arrays.Add(array);

                            currentIndex += 3;
                            remainingNumbers -= 3;
                        }

                        byte[] okBytes = Encoding.UTF8.GetBytes("OK");
                        udpServer.Send(okBytes, okBytes.Length, clientEndpoint);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                udpServer.Close();
            }
        }
    }
}
