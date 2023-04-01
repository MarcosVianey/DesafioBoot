using Amazon.DynamoDBv2.DocumentModel;
using Bootcamp2;
using Bootcamp2.Controller;
using CMConnect.Kernel.DTO.Cadastro;
using CsvHelper;
using Amazon = Bootcamp2.Controller.Amazon;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/",s => new StoreController().GetAmazonProducts("ps4"));

await app.RunAsync();

// Search(new MercadoLivre(), "ps4");
// Search(new Bootcamp2.Controller.Amazon(), "ps4");
//
// Get(new MercadoLivre(), new Product(){Id = "MLB16650345", CategoryId = "MLB11172"});
// // Search(new MercadoLivre(), "ps4");
// //
// void Search(Creator creator, string termo)
// {
//     creator.Search(termo);
// }
// //
// void Get(Creator creator, Product product)
// {
//     creator.Get(product);
// }
