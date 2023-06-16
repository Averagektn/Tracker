using System.Net.Sockets;

public class Client
{
    public static void Main()
    {
        string serverIP = "127.0.0.1";
        int serverPort = 12345;
        string stopWord = "done";
        Console.WriteLine("Enter file name");
        string outputFile = Console.ReadLine();
        var client = new TcpClient();

        try
        {
            client.Connect(serverIP, serverPort);
            Console.WriteLine("Connected!");

            NetworkStream stream = client.GetStream();
            bool isSending = true;
            while (isSending && client.Connected)
            {
                Console.WriteLine("Enter 3 numbers or 'done' to stop:");
                string? input = Console.ReadLine();

                if (input == null || input == stopWord)
                {
                    isSending = false;
                }
                else
                {
                    string[] numbers = input.Split(' ');

                    if (numbers.Length != 3)
                    {
                        Console.WriteLine("Error: incorrect input");
                        continue;
                    }

                    try
                    {
                        byte[] sendBytes = new byte[12];
                        for (int i = 0; i < 3; i++)
                        {
                            int number = int.Parse(numbers[i]);
                            Buffer.BlockCopy(BitConverter.GetBytes(number), 0, sendBytes, i * sizeof(int), sizeof(int));
                        }
                        stream.Write(sendBytes, 0, sendBytes.Length);
                        Console.WriteLine("Data sent successfully");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: incorrect numbers");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Server error: " + ex.Message);
                        break;
                    }
                }
            }
            using var writer = new StreamWriter(outputFile, true);
            writer.Write(string.Empty);

            bool waiting = true;
            while (waiting)
            {
                while (stream.DataAvailable)
                {
                    byte[] receiveBytes = new byte[2 * sizeof(int)];
                    stream.Read(receiveBytes, 0, receiveBytes.Length);

                    int number1 = BitConverter.ToInt32(receiveBytes, 0);
                    int number2 = BitConverter.ToInt32(receiveBytes, sizeof(int));

                    writer.WriteLine($"{number1} {number2}");

                    Console.WriteLine($"Data received: {number1} {number2}");
                    waiting = false;
                }
            }

            Console.WriteLine("All points were sent");
        }
        catch
        {
            Console.WriteLine("Data transmission error");
        }
        finally
        {
            client.Close();
            Console.WriteLine("Connection closed");
            Console.ReadLine();
        }
        
    }
}