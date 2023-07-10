using System;

namespace Charp_modul10_dz
{
    abstract class Worker
    {
        public Worker(WorkerPosition position) 
        {
            Position = position;
        }
        public WorkerPosition Position { get; }

        public void PrintInfoAboutClient(Client client)
        {
            var res = client.GetClientInfo(Position);
            Console.WriteLine(res);
        }

        public void SetField(Client client, string data, Command command)
        {
            client.SetField(data, command, Position);
        }
    }
}
