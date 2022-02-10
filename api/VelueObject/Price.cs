namespace CloudLabs.gRPC.API.VelueObject;

public class Price
{
    public Int32 Value { get; set; }
    public string Symbol { get; set; } = null!;
    public Int64 Datetime { get; set; }
}