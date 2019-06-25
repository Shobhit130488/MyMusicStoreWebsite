using System.Collections.Generic;
using System.Web;
using MusicStore.Core.Models;
using System.Web.Script.Serialization; // for serialize and deserialize  
using System.IO; // for File operation 
using Newtonsoft.Json;
using System.Linq;
using MusicStore.Core.Interfaces.Repository;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MusicStore.Infrastructure.Repository
{
   
    public class DatabaseCallImpl : IDatabaseCalls
    {
        public DatabaseCallImpl() { }

        public string AddToCart(DataContentsModel dataset)
        {
            string filePath = Path.GetFullPath(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).ToString()
                                                + Constants.Constants.cartUrl);
            var jsonList = GetAllData(filePath);

            if (jsonList == null)
            {
                return Constants.Constants.cartDataNotAvailable;
            }

            jsonList.Add(dataset);

            string response = WriteData(jsonList, filePath);

            if (response == Constants.Constants.successfull)

                return Constants.Constants.addToCart;
            else

                return Constants.Constants.notAddedToCart;
        }

        public string RemoveFromCart(int Id)
        {
            string filePath = Path.GetFullPath(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).ToString()
                                                + Constants.Constants.cartUrl);
            var jsonList = GetAllData(filePath);
            if (jsonList == null || !jsonList.Any())
            {
                return Constants.Constants.emptyCart;
            }
            DataContentsModel item = jsonList.First(x => x.Id == Id);

            jsonList.Remove(item);
            
            string response = WriteData(jsonList, filePath);

            if (response == Constants.Constants.successfull)
                return Constants.Constants.removeFromCart;
            else
                return Constants.Constants.cannotRemoveFromCart;
        }

        public List<DataContentsModel> GetAllData(string Url)
        {

            try
            { 
                string data = File.ReadAllText(Url);
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var songlist = JsonConvert.DeserializeObject<List<DataContentsModel>>(data);
                return songlist;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string WriteData(List<DataContentsModel> dataset, string url)
        {

            string json = JsonConvert.SerializeObject(dataset);

            //write string to file
            try
            {
                File.WriteAllText(url, json);
                return Constants.Constants.successfull;
            }
            catch (Exception ex)
            {
                return Constants.Constants.unsuccessfull;
            }

        }


    }
}