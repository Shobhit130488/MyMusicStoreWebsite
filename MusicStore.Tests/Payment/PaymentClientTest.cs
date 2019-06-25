using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.PaymentClient;
using System.Configuration;
using MusicStore.Core.Models;

namespace MusicStore.Tests.Payment
{
    [TestClass]
    public class PaymentClientTest
    {
        [TestMethod]
        public void MakePaymentTest()
        {
            PaymentClient paymentClient = new PaymentClient();
            string strNVP = createStrNVP();
            string strNVPSandboxServer = createstrNVPSandboxServer();
            string response = paymentClient.MakePayment(strNVP, strNVPSandboxServer);
            Assert.IsNotNull(response);

        }
        private string createStrNVP()
        {
            CustomerDetails customerDetails = SetModelData();
            string strUsername = ConfigurationManager.AppSettings["InStoreAPIUsername"].ToString();
            string strPassword = ConfigurationManager.AppSettings["InStoreAPIPassword"].ToString();
            string strSignature = ConfigurationManager.AppSettings["InStoreAPISignature"].ToString();
            string strCredentials = "USER=" + strUsername +
            "&PWD=" + strPassword + "&SIGNATURE=" + strSignature;
            string strAPIVersion = "60.0";
            string strNVP = "METHOD=DoDirectPayment" +
                          "&VERSION=" + strAPIVersion +
                          "&PWD=" + strPassword +
                          "&USER=" + strUsername +
                          "&SIGNATURE=" + strSignature +
                          "&PAYMENTACTION=Sale" +
                          "&IPADDRESS=" + customerDetails.customerIp +
                          "&RETURNFMFDETAILS=0" +
                          "&CREDITCARDTYPE=" + "Visa" +
                          "&ACCT=" + "4111111111111111" +
                          "&EXPDATE=" + customerDetails.CardExpiryMonth + customerDetails.CardExpiryYear +
                          "&CVV2=" + customerDetails.CardCCVNo +
                          "&STARTDATE=" +
                          "&ISSUENUMBER=" +
                          "&EMAIL=" + customerDetails.EmailId +
                          //the following  represents the billing details
                          "&FIRSTNAME=" + customerDetails.FirstName +
                          "&LASTNAME=" + customerDetails.LastName +
                          "&STREET=" + customerDetails.Address +
                          "&STREET2=" + "" +
                          "&CITY=" + "Memphsis" +
                          "&STATE=" + "TN" +
                          "&COUNTRYCODE=US" +
                          "&ZIP=" + "38134" +
                          "&AMT=" + customerDetails.payableAmount
                          + "&CURRENCYCODE=USD" +
                          "&DESC=Test Sale Tickets" +
                          "&INVNUM=" + "";
            return strNVP;
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
        private string createstrNVPSandboxServer()
        {
            return  ConfigurationManager.AppSettings["NVPSandboxServer"].ToString();
        }
    }
}
