using MusicStore.Core.Models;

namespace MusicStore.Core.Interfaces.Repository
{
   public interface IPaymentGateway
    {
        string FetchedCustomerDetails(CustomerDetails customerDetails);
    }
}
