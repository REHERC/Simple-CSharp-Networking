﻿using Networking;
using Networking.Nodes;
using Networking.Packets;
using static System.Console;

internal class ClientProgram
{
	static void Main()
	{
		Title = "TCP Client";

		var client = new Networker<Client>("127.0.0.1", 5000);
		client.OnPacketReceived += (sender, packet) =>
		{
			packet?.Run();
		};

		client.Start();

		while (client.Started)
		{
			client.SendPacket(LogMessage.Create(ReadLine()));
		}
		
		ReadLine();
	}


	public static void Nothing()
	{
		Title = "TCP Client";

		var client = new Networking.Nodes.Client("127.0.0.1", 5000);
		client.Start();

		using (var writer = client.CreateWriter())
		{
			while (client.Running)
			{
				writer.WriteLine(ReadLine());
				writer.Flush();
			}
		}
	}
}