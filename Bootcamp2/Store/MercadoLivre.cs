using Bootcamp2.Interfaces;
using CMUtil;
using Newtonsoft.Json.Linq;

namespace Bootcamp2.Store;

public class MercadoLivre : IStore
{
    public string BaseUrl { get; set; }
    public Dictionary<string, string> Header { get; set; }
    
    public MercadoLivre()
    {
        BaseUrl = "https://api.mercadolibre.com";
        Header = new Dictionary<string, string>();
        Header.Add("Authorization", "Bearer 0UgEpizqJM7CSl3O9nbIzrTvTuaU2JZG");
    }
    
    public async Task<List<Product>> Search(string termo)
    {
        var query = new Dictionary<string, object>();
        query.Add("q", termo);
        query.Add("status", "active");
        
        var list = RestClient.Use(BaseUrl).Get<JObject>(BaseUrl+"/sites/MLB/search", query, Header);

        List<Product> result = new List<Product>();
        try
        {
            var productsList = list["results"].ToList();
            productsList.ForEach(p => result.Add(Product.MLBToProdutoDTO(p)));
        }
        catch(Exception e)
        {
            throw new Exception("Deu ruim!\n" + e.Message);
        }

        return result;
    }
    
    public void Get(Product product)
    {
        var itemDescription = RestClient.Use(BaseUrl).Get<JObject>(BaseUrl+$"/products/{product.Id}", null, Header);
        var itemCategory = RestClient.Use(BaseUrl).Get<JObject>(BaseUrl+$"/categories/{product.CategoryId}", null, Header);
        
        try
        {
            product.Description = itemDescription["short_description"]["content"].ToString();
            product.Category = itemCategory["name"].ToString();
        }
        catch(Exception e)
        {
            throw new Exception("Deu ruim!\n" + e.Message);
        }
    }
}