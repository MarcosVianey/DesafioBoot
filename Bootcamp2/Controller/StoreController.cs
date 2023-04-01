namespace Bootcamp2.Controller;

public class StoreController
{
    public async Task<List<Product>> GetMLProducts(string termo)
    {
        var response = Factory.GetStore("ML");
        return await response.Search(termo);
    }
    
    public async Task<List<Product>> GetAmazonProducts(string termo)
    {
        var response = Factory.GetStore("AWS");
        return await response.Search(termo);
    }
    
    
}