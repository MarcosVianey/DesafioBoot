using Newtonsoft.Json.Linq;

namespace Bootcamp2.Interfaces;

public interface IStore
{
    public string BaseUrl { get; set; }
    public Dictionary<string, string> Header { get; set; }
    
    public Task<List<Product>> Search(string termo);
    public void Get(Product product);
}