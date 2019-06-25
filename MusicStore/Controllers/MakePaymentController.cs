using MusicStore.Core.Models;
using System.Web.Mvc;
using MusicStore.Core.Interfaces.Repository;


namespace MusicStore.Controllers
{

    public class MakePaymentController : Controller
    {
        // GET: MakePayment
        private readonly IPaymentGateway paymentGateway;

        public MakePaymentController() { }
        
        public MakePaymentController(IPaymentGateway paymentGateway)
        {
            this.paymentGateway = paymentGateway;
        }

        [Route("pay/creditcard")]
        public ActionResult Index(CartAmount cartamount)
        {
            CustomerDetails customerDetails = new CustomerDetails();
            customerDetails.payableAmount = cartamount.amount.ToString();
            return View(customerDetails);
        }
        [HttpPost]
        public ActionResult pay(CustomerDetails model)
        {
           
            if (ModelState.IsValid)
            {

                model.CardFee = 100;
                model.customerIp = "172.10.114";

                string paymentconfirmation = paymentGateway.FetchedCustomerDetails(model);

                ViewBag.Data = paymentconfirmation;
                return View("index",model);
            }
            else
            {
                ViewBag.Data = "Enter Valid Details";
                return View("index",model);
            }
            
        }

    }
}