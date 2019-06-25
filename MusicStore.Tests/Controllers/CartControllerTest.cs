using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MusicStore.Controllers;
using MusicStore.Core.Interfaces.Repository;
using MusicStore.Core.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicStore.Tests.Controllers
{
    [TestClass]
    public class CartControllerTest
    {
        

        [TestMethod]
        public void WhenCartIsEmpty()
        {
            List<DataContentsModel> data = new List<DataContentsModel>();
            
            Mock<IDatabaseCalls> mock = new Mock<IDatabaseCalls>();
            mock.Setup(g => g.GetAllData(It.IsAny<string>())).Returns(data);
            CartController controller = new CartController(mock.Object);
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void WhenCartDataNotRecieved()
        {
            List<DataContentsModel> data = null;

            Mock<IDatabaseCalls> mock = new Mock<IDatabaseCalls>();
            mock.Setup(g => g.GetAllData(It.IsAny<string>())).Returns(data);
            CartController controller = new CartController(mock.Object);
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Index()
        {
            List<DataContentsModel> data = SetListData();

            Mock<IDatabaseCalls> mock = new Mock<IDatabaseCalls>();
            mock.Setup(g => g.GetAllData(It.IsAny<string>())).Returns(data);
            CartController controller = new CartController(mock.Object);
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddtoCartDataNotFound()
        {
            string response = "Cart data not available";
            // Act
            DataContentsModel dataContentModel = SetModelData();
            Mock<IDatabaseCalls> mock = new Mock<IDatabaseCalls>();
            mock.Setup(g => g.AddToCart(It.IsAny<DataContentsModel>())).Returns(response);
            CartController controller = new CartController(mock.Object);
            string res = controller.Index(dataContentModel);
            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(res, "Cart data not available");
        }

        [TestMethod]
        public void AddToCart()
        {
            string response = "Item added to cart";
            // Act
            DataContentsModel dataContentModel = SetModelData();
            Mock<IDatabaseCalls> mock = new Mock<IDatabaseCalls>();
            mock.Setup(g => g.AddToCart(It.IsAny<DataContentsModel>())).Returns(response);
            CartController controller = new CartController(mock.Object);
            string res = controller.Index(dataContentModel);
            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(res, "Item added to cart");
        }


        [TestMethod]
        public void RemovefromCartDataNotFound()
        {
            string res = "Cart is empty";

            Mock<IDatabaseCalls> mock = new Mock<IDatabaseCalls>();
            mock.Setup(g => g.RemoveFromCart(It.IsAny<int>())).Returns(res);

            CartController controller = new CartController(mock.Object);
            string response = controller.RemoveItem(35);

            Assert.IsNotNull(response);
            Assert.AreEqual(response, "Cart is empty");
        }


        [TestMethod]
        public void RemovefromCart()
        {
            string res = "Item removed from cart";

            Mock<IDatabaseCalls> mock = new Mock<IDatabaseCalls>();
            mock.Setup(g => g.RemoveFromCart(It.IsAny<int>())).Returns(res);

            CartController controller = new CartController(mock.Object);
            string response = controller.RemoveItem(35);
   
            Assert.IsNotNull(response);
            Assert.AreEqual(response, "Item removed from cart");
        }

        private List<DataContentsModel> SetListData()
        {
            List<DataContentsModel> list = new List<DataContentsModel>();
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
