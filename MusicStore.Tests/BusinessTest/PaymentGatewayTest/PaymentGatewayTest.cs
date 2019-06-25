using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MusicStore.Core.Interfaces.Repository;
using MusicStore.Business.PaymentGateway;
using MusicStore.Core.Models;

namespace MusicStore.Tests.BusinessTest.PaymentGatewayTest
{
    [TestClass]
    public class PaymentGatewayTest
    {
        [TestMethod]
        public void FetchedCustomerDetailsTest()
        {
            CustomerDetails customerDetails = SetModelData();
            string response = "Payment cannot be done";
            Mock<IPaymentClient> mock = new Mock<IPaymentClient>();
            mock.Setup(g => g.MakePayment(It.IsAny<string>(), It.IsAny<string>())).Returns(response);
            PaymentGateway paymentGateway = new PaymentGateway(mock.Object);
            string res=paymentGateway.FetchedCustomerDetails(customerDetails);
            Assert.IsNotNull(res);
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
            customerDetails.PhoneNo = "8860593898";
            customerDetails.State = "NY";
            return customerDetails;
        }
    }
}
