using CMUtil.DB;
using Newtonsoft.Json.Linq;

namespace Bootcamp2;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal ActualPrice { get; set; }
    public string Thumbnail { get; set; }
    public string Category { get; set; }
    public string CategoryId { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public string Source { get; set; }

    public static Product AmazonToProdutoDTO(JToken produto)
    {
        return new Product()
        {
            Id = produto["asin"].Value<String>(),
            Name = produto["title"].Value<String>(),
            ActualPrice = produto["price"]["current_price"].Value<Decimal>(),
            Thumbnail = produto["thumbnail"].Value<String>(),
            Url = produto["url"].Value<String>(),
            Source = "AMAZON"
        };
    }
    
    public static Product MLBToProdutoDTO(JToken produto)
    {
        return new Product()
        {
            Id = produto["catalog_product_id"].ToString(),
            Name = produto["title"].ToString(),
            ActualPrice = Decimal.Parse(produto["price"].ToString()),
            Thumbnail = produto["thumbnail"].ToString(),
            Url = produto["permalink"].ToString(),
            CategoryId = produto["category_id"].ToString(),
            Source = "ML"
        };
        
    }
}

