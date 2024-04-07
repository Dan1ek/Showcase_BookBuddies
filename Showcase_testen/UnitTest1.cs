
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Showcase_BookBuddies.Controllers;
using Showcase_BookBuddies.Data;

namespace Showcase_BookBuddies.Tests.Controllers
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[Test]
        //[Authorize]
        //public void Index_ReturnsView()
        //{
        //    // Arrange
        //    var mockLogger = new Mock<ILogger<HomeController>>();
        //    var mockSignInManager = new Mock<SignInManager<IdentityUser>>();
        //    var mockUserStore = new Mock<IUserStore<IdentityUser>>();

        //    var mockUserManager = new Mock<UserManager<IdentityUser>>(mockUserStore.Object, null, null, null, null, null, null, null, null);

        //    var mockDbContext = new Mock<ApplicationDbContext>();


        //    // Set up mock behavior if needed
        //    // For example:
        //    // mockSignInManager.Setup(s => s.IsSignedIn(It.IsAny<ClaimsPrincipal>())).Returns(true);

        //    var controller = new HomeController(mockLogger.Object, mockUserManager.Object, mockDbContext.Object, mockSignInManager.Object);

        //    // Act
        //    var result = controller.Index();

        //    // Assert
        //    Assert.IsInstanceOf<IActionResult>(result);
        //}

        //[Test]
        //[Authorize(Roles = "admin")]
        //public void Admin_ReturnsViewForAuthorizedUsers()
        //{
        //    // Arrange
        //    var mockLogger = new Mock<ILogger<HomeController>>();
        //    var controller = new HomeController(mockLogger.Object);

        //    // Act
        //    var result = controller.DeleteBookList();

        //    // Assert
        //    Assert.IsInstanceOf<IActionResult>(result);

        //}

        //[Test]
        //[Authorize]
        //public void AllLists_ReturnsViewForAuthorizedUsers()
        //{
        //    // Arrange
        //    var mockLogger = new Mock<ILogger<HomeController>>();
        //    var controller = new HomeController(mockLogger.Object);

        //    // Act
        //    var result = controller.AllLists();

        //    // Assert
        //    Assert.IsInstanceOf<IActionResult>(result);


        //}
        [Test]
        [Authorize]
        public void ChatHub_ReturnsViewForAuthorizedUsers()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockLogger.Object);

            // Act
            var result = controller.ChatHub();

            // Assert
            Assert.IsInstanceOf<IActionResult>(result);


        }


    }
}