using Microsoft.VisualStudio.TestTools.UnitTesting;
using NITBook.Controllers;
using System.Web.Mvc;

namespace NITBookUnitTest
{
    [TestClass]
    public class HomeControllerUnitTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controllor = new HomeController();
            ViewResult result = controllor.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BookSort()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.BookSort() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Info()
        {
            HomeController controllrt = new HomeController();
            ViewResult result = controllrt.Info() as ViewResult;
            Assert.AreEqual("NIT图书馆信息",result.ViewBag.Message);
        }

        [TestMethod]
        public void Sort()
        {
            HomeController controllrt = new HomeController();
            ViewResult result = controllrt.Sort() as ViewResult;
            Assert.AreEqual("NIT图书分类", result.ViewBag.Message);
        }

        [TestMethod]
        public void List()
        {
            HomeController controllrt = new HomeController();
            ViewResult result = controllrt.List() as ViewResult;
            Assert.AreEqual("NIT图书排行", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            HomeController controllrt = new HomeController();
            ViewResult result = controllrt.Contact() as ViewResult;
            Assert.AreEqual("联系我们", result.ViewBag.Message);
        }
    }
}
