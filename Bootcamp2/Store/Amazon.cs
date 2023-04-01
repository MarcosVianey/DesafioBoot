using Bootcamp2.Interfaces;
using CMUtil;
using Newtonsoft.Json.Linq;

namespace Bootcamp2.Store;

public class Amazon : IStore
{
    public string BaseUrl { get; set; }
    public Dictionary<string, string> Header { get; set; }
    
    public Amazon()
    {
        BaseUrl = "https://amazon23.p.rapidapi.com";
        Header = new Dictionary<string, string>();
        Header.Add("X-RapidAPI-Key", "c3c7dec8b2msh11b9af671cb7e29p14b408jsnf34ad4d67522");
        Header.Add("X-RapidAPI-Host", "amazon23.p.rapidapi.com");
    }
    
    public async Task<List<Product>> Search(string termo)
    {
        var query = new Dictionary<string, object>();
        query.Add("query", termo);
        query.Add("country", "BR");
        
        var list = RestClient.Use(BaseUrl).Get<JObject>(BaseUrl+"/product-search", query, Header);
        
        List<Product> result = new List<Product>();
        try
        {
            var productsList = list["result"].ToList();
            productsList.ForEach(p => result.Add(Product.AmazonToProdutoDTO(p)));
        }
        catch(Exception e)
        {
            throw new Exception("Deu ruim!\n" + e.Message);
        }

        return result;
    }
    
    public void Get(Product product)
    {
        var query = new Dictionary<string, object>();
        query.Add("asin", product.Id);
        query.Add("country", "BR");

        var item = RestClient.Use(BaseUrl).Get<JObject>(BaseUrl + "/product-details", query, Header)["result"][0];
        
        try
        {
            product.Description = item["description"].Value<string>() ?? "";
            product.Category = item["categories"].ToList().Last()["category"].ToString();
        }
        catch(Exception e)
        {
            throw new Exception("Deu ruim!\n" + e.Message);
        }
    }
}