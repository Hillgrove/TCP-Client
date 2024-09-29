﻿
using System.Net.Sockets;

Console.WriteLine("TCP Client");

TcpClient socket = new TcpClient("127.0.0.1", 7);
NetworkStream ns = socket.GetStream();
StreamReader reader = new StreamReader(ns);
StreamWriter writer = new StreamWriter(ns);

bool keepSending = true;
while (keepSending)
{
    string message = Console.ReadLine();
    writer.WriteLine(message);
    writer.Flush();
    
    string response = reader.ReadLine();
    Console.WriteLine(response);

    if (message.ToLower() == "stop")
    {
        keepSending = false;
    }
}

socket.Close();