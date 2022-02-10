using Bogus;
using CloudLabs.gRPC.API.VelueObject;
using Grpc.Core;

namespace CloudLabs.gRPC.API.Services;

public class PricingService : PricingFeed.PricingFeedBase
{
    private readonly ILogger<PricingService> _logger;
    private readonly IList<Price> _prices;

    public PricingService(ILogger<PricingService> logger)
    {
        _logger = logger;
        _prices = new Faker<Price>()
            .RuleFor(p => p.Value, x => x.Random.Int(0, 10000))
            .RuleFor(p => p.Symbol, x => x.Finance.Currency().Description)
            .RuleFor(p => p.Datetime, _ => _.Date.Past().Ticks)
            .Generate(300);
    }

    public override async Task SubscribePricing(PricingRequest request,
        IServerStreamWriter<PricingResponse> responseStream, ServerCallContext context)
    {
        // while (!context.CancellationToken.IsCancellationRequested)
        // {
        // }

        foreach (var price in _prices)
        {
            await responseStream.WriteAsync(new PricingResponse()
            {
                Value = price.Value,
                Symbol = price.Symbol,
                Timestamp = price.Datetime
            });
        }
    }
}