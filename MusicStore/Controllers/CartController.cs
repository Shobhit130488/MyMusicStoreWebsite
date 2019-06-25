using MusicStore.Core.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using MusicStore.Core.Interfaces.Repository;
using System;
using System.IO;


namespace MusicStore.Controllers
{

    public class CartController : Controller
    {
        private readonly IDatabaseCalls _dbCall;

       
        public CartController(IDatabaseCalls _dbCall)
        {
            this._dbCall = _dbCall;
        }

        // GET: Cart
        public ActionResult Index()
        {
             return View();
        }

        public PartialViewResult cartlist()
        {
            string filePath = Path.GetFullPath(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).ToString() 
                                                +Constants.Constants.cartUrl);
            List<DataContentsModel> listofselecteddata = _dbCall.GetAllData(filePath);

            return PartialView("_cartlist", listofselecteddata);
        }
        
        [HttpPost]
        public string Index(DataContentsModel dataset)
        {
          
            string response = _dbCall.AddToCart(dataset);
            return response;

        }
        [HttpPost]
        public string RemoveItem(int ID)
        {
            string response = _dbCall.RemoveFromCart(ID);
            return response;
        }
        
    }
}