using Microsoft.Extensions.Logging;
using Moq;
using StructureOfProject.Controllers;
using StructureOfProject.DataAccessLayer.Repositories;
using StructureOfProject.Models;
using StructureOfProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureOfProject.UnitTests
{
    [TestClass]
    public class ControllerUnitTests
    {
        private readonly ILogger<UserController> _logger;
        [TestMethod]
        public async Task GetPeopleByIdAsync_GetbyId_ReturnsPeopleWithSameId()
        {
            // Arrange
            var P = new People { Id = 1, Name = "HJ" };
            var mockRepositories = new Mock<IPeopleRepositories>();
            mockRepositories.Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(P);
            //Console.WriteLine(mockService);

            var peopleService = new PeopleService(mockRepositories.Object);
            var controller = new UserController(_logger, peopleService);

            // Action
            var contentresult = await controller.GetPeopleByIdAsync(P.Id);
            

            // Assert
            Assert.AreEqual(P.Id, contentresult.Value.Id);
            //Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(P.Name, contentresult.Value.Name);
        }

        [TestMethod]
        public async Task GetPeople_GetPeople_GetPeople()
        {
            IEnumerable<People> users = new List<People>()
            {
            new People(){Id = 1, Name = "Danish"},
            new People(){Id = 2, Name = "Kumar"}
            };
            // Arrange
            var P = new People { Id = 1, Name = "HJ" };
            var mockRepositories = new Mock<IPeopleRepositories>();
            mockRepositories.Setup(x => x.GetPeopleAsync())
                .ReturnsAsync(users);
            //Console.WriteLine(mockService);

            var peopleService = new PeopleService(mockRepositories.Object);
            var controller = new UserController(_logger, peopleService);

            // Action
            var contentresult = await controller.GetPeople();


            // Assert
            Assert.AreEqual(users, contentresult);
            //Assert.IsNotNull(contentResult.Content);
            //Assert.AreEqual(P.Name, contentresult.Value.Name);
        }
        [TestMethod]
        public async Task AddpersonAsync_AddingPeople_Getperson()
        {
            // Arrange
            var P = new People {  Name = "HJ" };
            var mockRepositories = new Mock<IPeopleRepositories>();
            mockRepositories.Setup(x => x.AddpersonAsync(P))
                .ReturnsAsync(P);
            //Console.WriteLine(mockService);

            var peopleService = new PeopleService(mockRepositories.Object);
            var controller = new UserController(_logger, peopleService);

            // Action
            var contentresult = await controller.PostPeopleDetailAsync(P);


            //Assert
            Assert.AreEqual(P.Id, contentresult.Value.Id);
            Assert.AreEqual(P.Name, contentresult.Value.Name);
        }

        [TestMethod]
        public async Task DeletePeopleDetailAsync_DeletingPeople_Deletingpeople()
        {
            // Arrange
            var P = new People { Name = "HJ" };
            var mockRepositories = new Mock<IPeopleRepositories>();
            mockRepositories.Setup(x => x.DeleteAsync(P.Id))
                .ReturnsAsync(true);
            //Console.WriteLine(mockService);

            var peopleService = new PeopleService(mockRepositories.Object);
            var controller = new UserController(_logger, peopleService);

            // Action
            var contentresult = await controller.DeletePeopleDetailAsync(P.Id);

            //Assert
            Assert.AreEqual("This User is deleted", contentresult.ToString());
            //Assert.AreEqual(P.Name, contentresult.Value.Name);
        }

        [TestMethod]
        public async Task EditPeopleDetailAsync_EditingPeople_Deletingpeople()
        {
            // Arrange
            var P = new People { Name = "HJ" };
            var mockRepositories = new Mock<IPeopleRepositories>();
            mockRepositories.Setup(x => x.UpdatepeopleAsync(P.Id, P))
                .ReturnsAsync(P);
            //Console.WriteLine(mockService);

            var peopleService = new PeopleService(mockRepositories.Object);
            var controller = new UserController(_logger, peopleService);

            // Action
            var contentresult = await controller.EditPeopleDetailAsync(P.Id, P);

            //Assert
            Assert.AreEqual(P, contentresult.Value);
            
        }



    }
}
