// See https://aka.ms/new-console-template for more information

using CloudLabs.gRPC.API;
using Grpc.Net.Client;

Console.WriteLine("Hello, World!");

using var channel = GrpcChannel.ForAddress("https://localhost:7179");
var client = new Greeter.GreeterClient(channel);

var response = await client.SayHelloAsync(new HelloRequest() {Name = "Kris"});

Console.WriteLine(response);