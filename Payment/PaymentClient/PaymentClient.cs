using System;
using System.Net;
using System.IO;
using System.Collections;
using System.Web;
using MusicStore.Core.Interfaces.Repository;

namespace Payment.PaymentClient
{
    public class PaymentClient : IPaymentClient
    {

        public string MakePayment(string strNVP, string strNVPSandboxServer)
        {
            try
            {
                //Create web request and web response objects, 

                HttpWebRequest wrWebRequest = (HttpWebRequest)WebRequest.Create(strNVPSandboxServer);
                wrWebRequest.Method = "POST";
                StreamWriter requestWriter = new StreamWriter(wrWebRequest.GetRequestStream());
                requestWriter.Write(strNVP);
                requestWriter.Close();

                // Get the response.
                HttpWebResponse hwrWebResponse = (HttpWebResponse)wrWebRequest.GetResponse();
                StreamReader responseReader =
                    new StreamReader(wrWebRequest.GetResponse().GetResponseStream());

                //and read the response
                string responseData = responseReader.ReadToEnd();
                responseReader.Close();

                string result = HttpContext.Current.Server.UrlDecode(responseData);

                string[] arrResult = result.Split('&');
                
                Hashtable htResponse = BuildResponse(arrResult);
               
                return BuildAcknowledge(htResponse);
                
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return error;
            }

        }
        private Hashtable BuildResponse(string[] arrResult)
        {
            Hashtable htResponse = new Hashtable();
            string[] responseItemArray;
            foreach (string responseItem in arrResult)
            {
                responseItemArray = responseItem.Split('=');
                htResponse.Add(responseItemArray[0], responseItemArray[1]);
            }
            return htResponse;
        }
        private string BuildAcknowledge(Hashtable htResponse)
        {
            string strAck = htResponse["ACK"].ToString();
            if (strAck == "Success" || strAck == "SuccessWithWarning")
            {

                string strAmt = htResponse["AMT"].ToString();
                string strCcy = htResponse["CURRENCYCODE"].ToString();
                string strTransactionID = htResponse["TRANSACTIONID"].ToString();
                string strSuccess = "Thank you, your order for: $" +
                    strAmt + " " + strCcy + " has been processed.";
                return strSuccess;
            }
            else
            {

                string error = "Error code: " + htResponse["L_ERRORCODE0"].ToString();
                return error;

            }
        }
    }

}
