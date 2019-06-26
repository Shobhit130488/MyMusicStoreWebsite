using MusicStore.Core.Interfaces.Repository;
using MusicStore.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly IDatabaseCalls _dbCall;


        public HomeController(IDatabaseCalls _dbCall)
        {
            this._dbCall = _dbCall;
        }

        public ActionResult Index()
        {
           
            string filePath = Path.GetFullPath(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory).ToString() 
                                                + Constants.Constants.dataUrl);
            List<DataContentsModel> data = _dbCall.GetAllData(filePath);
            if (data == null|| !data.Any())
            {
                return View("Error");
            }
            return View(data);

        }

      
    }
}