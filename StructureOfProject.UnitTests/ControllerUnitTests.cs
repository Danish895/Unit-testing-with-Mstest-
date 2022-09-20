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
    }
}
