using System.Text.Json;
using Grpc.Net.Client;
using LibraryApp;

var channel = GrpcChannel.ForAddress("https://localhost:7031");
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