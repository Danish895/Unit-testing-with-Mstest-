using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using StructureOfProject.Controllers;
using StructureOfProject.DataAccessLayer.ApplicationDbContext.AppDbContext;
using StructureOfProject.DataAccessLayer.Repositories;
using StructureOfProject.Models;
using StructureOfProject.Services;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;

namespace StructureOfProject.UnitTests
{
    [TestClass]
    public class PeopleServiceTests
    {
        private readonly ILogger<UserController> _logger;
        private readonly IPeopleService _peopleService;
        private readonly IPeopleRepositories _peopleRepositories;
        private readonly UserController _Controller;
        private readonly AppDbContext _context;
        //private readonly ILogger<UserController> _logger;
        //private IPeopleService _peopleService;

        //public UserControllerTests(AppDbContext context, ILogger<UserController> logger, IPeopleService peopleService)
        //{
        //    _context = context;
        //    _logger = logger;
        //    _peopleService = peopleService;
        //    _Controller = new UserController(_logger, _peopleService);
        //}

        [TestMethod]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {

            //Arrange
            var unitTestController = new UnitTestController();

            //Act
            var result = unitTestController.CanBeCancelledBy(new Models.User { IsAdmin = true });

            //Assert
            Assert.IsTrue(result);
        }


        
        //[TestMethod]
        //public void GetReturnsPeople()
        //{
        //    // Arrange
        //    var mockRepository = new Mock<IPeopleService>();
        //    mockRepository.Setup(x => x.GetPeopleAsync())
        //        .Returns(new Peoples { Id = 1, Name = "cghj" });

        //    var controller = new PeopleService(mockRepository.Object);

        //    // Act
        //    IHttpActionResult actionResult = controller.GetPeopleAsync();
        //    var contentResult = actionResult as OkNegotiatedContentResult<People>;

        //    // Assert
        //    Assert.IsNotNull(contentResult);
        //    Assert.IsNotNull(contentResult.Content);
        //    Assert.AreEqual(42, contentResult.Content.Id);
        //}


        [TestMethod]
        public async Task GetByIdAsync_GetbyId_ReturnsPeopleWithSameId()
        {
            // Arrange
            var P = new People { Id = 1, Name = "HJ" };
            var mockRepositories = new Mock<IPeopleRepositories>();
            mockRepositories.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(P);
            Console.WriteLine(mockRepositories);

            var peopleService = new PeopleService(mockRepositories.Object);

            // Action
            var contentresult = await peopleService.GetByIdAsync(1);
           
            // Assert
            Assert.AreEqual(P.Id, contentresult.Id);
            //Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(P.Name, contentresult.Name);
            
        }
        //public async void GetPeopleAsync_getdata_ReturnsTrue()
        //{
        //Arrange
        //var peopleService = new PeopleService(_peopleRepositories);

        //Act  
        //var response = await peopleService.GetPeopleAsync();

        //Assert  
        //Assert.AreEqual(peopleService, data);
        //Assert.AreEqual(HttpStatusCode.OK, HttpContext.Equals();
        //Assert.AreEqual("application/json; charset=utf-8", HttpContext.response.Headers.ContentType?.ToString());
        //Assert.AreEqual("application/json; charset=utf-8", response.

        //var json = await response.Content.ReadAsStringAsync();
        //Assert.AreEqual("[\"value1\",\"value2\"]", json);
        // Arrange
        //    var peopleService = new PeopleService(_peopleRepositories);
        //    peopleService.Request = new HttpRequestMessage();
        //    controller.Configuration = new HttpConfiguration();

        //    // Act
        //    var response = controller.Get(10);

        //    // Assert
        //    Product product;
        //    Assert.IsTrue(response.TryGetContentValue<Product>(out product));
        //    Assert.AreEqual(10, product.Id);
        //}

        //{
        //    var serviceProvider = new ServiceCollection()
        //    .AddLogging()
        //    .BuildServiceProvider();

        //var factory = serviceProvider.GetService<ILoggerFactory>();

        //var logger = factory.CreateLogger<UserController>();
        //UserController home = new UserController(logger, _peopleService);
        //var result = home.GetPeople();

        //var data = _context.Peoples.ToListAsync();
        //Assert.AreEqual(result, data);
        //}
        //{
        //    var data = new List<People>
        //    {
        //        new People { Id = 1,Name = "BBB" }
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<People>>();
        //    mockSet.As<IQueryable<People>>().Setup(m => m.Provider).Returns(data.Provider);
        //    mockSet.As<IQueryable<People>>().Setup(m => m.Expression).Returns(data.Expression);
        //    mockSet.As<IQueryable<People>>().Setup(m => m.ElementType).Returns(data.ElementType);
        //    mockSet.As<IQueryable<People>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

        //    var mockContext = new Mock<AppDbContext>();
        //    mockContext.Setup(c => c.Peoples).Returns(mockSet.Object);

        //    var service = new PeopleRepositories(mockContext.Object);
        //    var peoples = service.GetPeopleAsync();

        //    Assert.AreEqual( peoples, data);
        //}
        [TestMethod]
        public async Task GetPeopleAsync_GetPeople_Getpeople()
        {
            // Arrange
            IEnumerable<People> users = new List<People>()
            {
            new People(){Id = 1, Name = "Danish"},
            new People(){Id = 2, Name = "Kumar"}
            };
            var mockRepositories = new Mock<IPeopleRepositories>();
            mockRepositories.Setup(x => x.GetPeopleAsync())
                .ReturnsAsync(users);
            var peopleService = new PeopleService(mockRepositories.Object);

            // Action
            var contentresult = await peopleService.GetPeopleAsync();

            // Assert
            Assert.AreEqual(users, contentresult);
        }

        [TestMethod]
        public async Task DeleteAsync_DeletingPeople_GetResult()
        {
            // Arrange
            var P = new People { Id = 1, Name = "HJ" };
            var mockRepositories = new Mock<IPeopleRepositories>();
            mockRepositories.Setup(x => x.DeleteAsync(P.Id))
                .ReturnsAsync(true);
            var peopleService = new PeopleService(mockRepositories.Object);

            // Action
            var contentresult = await peopleService.DeleteAsync(P.Id);

            // Assert
            Assert.AreEqual(true, contentresult);
        }

        [TestMethod]
        public async Task AddpersonAsync_AddingPeople_Getpeople()
        {
            // Arrange
            var P = new People { Id = 1, Name = "HJ" };
            var mockRepositories = new Mock<IPeopleRepositories>();
            mockRepositories.Setup(x => x.AddpersonAsync(P))
                .ReturnsAsync(P);
            var peopleService = new PeopleService(mockRepositories.Object);

            // Action
            var contentresult = await peopleService.AddpersonAsync(P);

            // Assert
            Assert.AreEqual(P.Id, contentresult.Id);
            Assert.AreEqual(P.Name, contentresult.Name);
        }
        [TestMethod]
        public async Task UpdatepeopleAsync_UpdatePeople_Getpeople()
        {
            // Arrange
            var P = new People { Id = 1, Name = "HJ" };
            var mockRepositories = new Mock<IPeopleRepositories>();
            mockRepositories.Setup(x => x.UpdatepeopleAsync(P.Id,P))
                .ReturnsAsync(P);
            var peopleService = new PeopleService(mockRepositories.Object);

            // Action
            var contentresult = await peopleService.UpdatepeopleAsync(P.Id , P);

            // Assert
            Assert.AreEqual(P.Id, contentresult.Id);
            Assert.AreEqual(P.Name, contentresult.Name);
        }
    } 
}