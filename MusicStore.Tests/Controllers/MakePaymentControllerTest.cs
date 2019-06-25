using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MusicStore.Controllers;
using MusicStore.Core.Interfaces.Repository;
using MusicStore.Core.Models;
using System.Web.Mvc;

namespace MusicStore.Tests.Controllers
{
    [TestClass]
    public class MakePaymentControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            MakePaymentController controller = new MakePaymentController();
            CartAmount cartamount = new CartAmount();
            cartamount.amount = 25.0M;
            // Act
            ViewResult result = controller.Index(cartamount) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void pay()
        {
  
            CustomerDetails customerDetails = SetModelData();
            string error = "Cannot make payment";

            Mock<IPaymentGateway> mock = new Mock<IPaymentGateway>();
            mock.Setup(g => g.FetchedCustomerDetails(It.IsAny<CustomerDetails>())).Returns(error);

            MakePaymentController controller = new MakePaymentController(mock.Object);

            ViewResult result = controller.pay(customerDetails) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        private CustomerDetails SetModelData()
        {
            CustomerDetails customerDetails = new CustomerDetails();
            customerDetails.FirstName = "Mohini";
            customerDetails.LastName = "Agarwal";
            customerDetails.payableAmount = "25.0";
            customerDetails.Address = "3/D Park avenue";
            customerDetails.CardCCVNo = "134";
            customerDetails.CardExpiryMonth = "Dec";
            customerDetails.CardExpiryYear = "2018";
            customerDetails.CardNo = "1234567889234566";
            customerDetails.EmailId = "mohini@gmail.com";
            customerDetails.PhoneNo = "8811293898";
            customerDetails.State = "NY";
            return customerDetails;
        }

    }
}
