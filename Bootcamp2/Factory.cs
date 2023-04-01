using Bootcamp2.Controller;
using Bootcamp2.Interfaces;
using MercadoLivre = Bootcamp2.Store.MercadoLivre;

namespace Bootcamp2;

public class Factory
{
    
    public static Dictionary<string, Type> StoreMap = new Dictionary<string, Type>()
        {
            { "ML", typeof(MercadoLivre) },
            { "AWS", typeof(Bootcamp2.Store.Amazon) }
        };
        
        public static IStore GetStore(string value)
        {
            var type = StoreMap[value].GetConstructor(new Type[] { });
            var instance = (IStore)type.Invoke(new object[] { });
            return instance;
        } 
}
