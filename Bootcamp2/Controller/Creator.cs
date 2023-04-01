using Bootcamp2.Interfaces;

namespace Bootcamp2.Controller;

abstract class Creator
{
    public abstract IStore FactoryMethod();

    public Task<List<Product>> Search(string termo)
    {
        var store = FactoryMethod();
        Console.WriteLine("Criado: ");
        var result = store.Search(termo);

        return result;
    }

    public void Get(Product product)
    {
        var store = FactoryMethod();
        Console.WriteLine("Criado: ");
        store.Get(product);
    }
    
}

class MercadoLivre : Creator
{
    public override IStore FactoryMethod()
    {
        return new Store.MercadoLivre();
    }
}

class Amazon : Creator
{
    public override IStore FactoryMethod()
    {
        return new Store.Amazon();
    }
}