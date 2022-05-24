using System.Collections.Generic;
using Moq;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BacEnd.Domain.Services;
using SOSU2022_BackEnd.Core.IServices;
using Xunit;

namespace SOSU2022_BackEnd.Core.Test.IServices
{
    public class ICaseOpeningServiceTest
    {
        [Fact]
        public void ICaseOpeningService_IsAvailable()
        {
            var service = new Mock<CaseOpeningService>().Object;
            Assert.NotNull(service);
        }

        [Fact]
        public void GetAll_NoParams_ReturnsListOfCaseOpening()
        {
            var mock = new Mock<ICaseOpeningService>();
            var fakeList = new List<CaseOpening>();
            mock.Setup(s => s.GetAll()).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList, service.GetAll());
        }

        [Fact]
        public void GetAll_WithParams_ReturnsListOfCaseOpening()
        {
            var mock = new Mock<ICaseOpeningService>();
            var fakeList = new List<CaseOpening>();
            mock.Setup(s => s.GetByCitizen("citizenId")).Returns(fakeList);
            var service = mock.Object;
            Assert.Equal(fakeList, service.GetByCitizen("citizenId"));
        }

        [Fact]
        public void Update_ReturnsCaseOpening()
        {
            var mock = new Mock<ICaseOpeningService>();
        }
    }
}