// See https://aka.ms/new-console-template for more information


using CloudLabs.gRPC.Client;
using Grpc.Net.Client;

Console.WriteLine("Hello, World!");

using var channel = GrpcChannel.ForAddress("https://localhost:7179");
var client = new PricingFeed.PricingFeedClient(channel);

var pricingStream  = client.SubscribePricing(new PricingRequest() {Symbol = "USD"});

while (await pricingStream.ResponseStream.MoveNext(CancellationToken.None))
{
    var crt = pricingStream.ResponseStream.Current;
    Console.WriteLine($"{crt.Value} - {crt.Symbol} - [{crt.Timestamp}]");    
}

