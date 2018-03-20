namespace ExamControl.Tests.Controllers
{
    using System.Web.Mvc;
    using ExamControl.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines the <see cref="HomeControllerTest" />
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// The Index
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
