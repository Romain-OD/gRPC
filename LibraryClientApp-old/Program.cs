using System.Text.Json;
using Grpc.Net.Client;
using Book;

var channel = GrpcChannel.ForAddress("https://localhost:7200");
var client = new BookCatalog.BookCatalogClient(channel);

var request = new BookDetailsRequest
{
    Id = 1
};

var response = await client.GetBookDetailsAsync(request);

Console.WriteLine(JsonSerializer.Serialize(response, new JsonSerializerOptions
{
    WriteIndented = true
}));

Console.ReadKey();