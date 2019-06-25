using MusicStore.Core.Models;
using System.Collections.Generic;

namespace MusicStore.Core.Interfaces.Repository
{
    public interface IDatabaseCalls
    {
        List<DataContentsModel> GetAllData(string url);
       
        string RemoveFromCart(int Id);

        string AddToCart(DataContentsModel dataset);
    }
}
