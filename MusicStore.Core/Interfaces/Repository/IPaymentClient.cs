
namespace MusicStore.Core.Interfaces.Repository
{
   public interface IPaymentClient
    {
        string MakePayment(string strNVP, string strNVPSandboxServer);
    }
}
