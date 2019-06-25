using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.Controllers;
using Moq;
using MusicStore.Core.Interfaces.Repository;
using MusicStore.Infrastructure.Repository;
using System.Collections.Generic;
using MusicStore.Core.Models;

namespace MusicStore.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void WhenDataisEmpty()
        {
           
            List<DataContentsModel> data = new List<DataContentsModel>();

            Mock<IDatabaseCalls> mock = new Mock<IDatabaseCalls>();
            mock.Setup(g => g.GetAllData(It.IsAny<string>())).Returns(data);

            HomeController controller = new HomeController(mock.Object);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Index()
        {

            List<DataContentsModel> data = SetListData();

            Mock<IDatabaseCalls> mock = new Mock<IDatabaseCalls>();
            mock.Setup(g => g.GetAllData(It.IsAny<string>())).Returns(data);

            HomeController controller = new HomeController(mock.Object);
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        private List<DataContentsModel> SetListData()
        {
            List < DataContentsModel > list= new List<DataContentsModel>();
            DataContentsModel data = SetModelData();
            list.Add(data);
            return list;
        }
        private DataContentsModel SetModelData()
        {
            DataContentsModel dataContentModel = new DataContentsModel();
            dataContentModel.Id = 35;
            dataContentModel.Artist = "Fresh Moods";
            dataContentModel.Title = "Aground";
            dataContentModel.Price = 25.0M;
            dataContentModel.Duration = "03.40 min";
            dataContentModel.ImageUrl = "../Content/Images/aground.jpeg";
            dataContentModel.Genre = "Jazz";
            return dataContentModel;
        }
    }
}
