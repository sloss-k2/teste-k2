using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebAPI.Controllers;

namespace WebAPI.Tests.Controllers
{
    [TestClass]
    public class SeguroControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            SeguroController controller = new SeguroController();

            NameValueCollection formValues = new NameValueCollection {
                { "cpf", "88855577799" },
                { "marcaModelo", "teste" },
                { "valor", "10000" }
            };

            var moqRequest = new Mock<HttpRequestBase>();
            moqRequest.Setup(r => r.Form).Returns(formValues);

            var context = new Mock<HttpContextBase>();
            context.SetupGet(x => x.Request).Returns(moqRequest.Object);            

            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);


            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Seguro", result.ViewBag.Title);
        }
    }
}
