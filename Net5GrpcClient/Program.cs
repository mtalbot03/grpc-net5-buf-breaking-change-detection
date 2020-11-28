using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Net5GrpcClient.Protos;

namespace Net5GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var request = new HelloRequest { Name = "Benjamin Franklin" };
            var response = await client.SayHelloAsync(request);

            Console.WriteLine(response.Message);
        }
    }
}
