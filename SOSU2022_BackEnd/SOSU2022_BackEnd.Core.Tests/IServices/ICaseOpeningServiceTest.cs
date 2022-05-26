using System.Collections.Generic;
using Moq;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BacEnd.Domain.Services;
using SOSU2022_BackEnd.Core.IServices;
using Xunit;

namespace SOSU2022_BackEnd.Core.Tests.IServices
{
    public class ICaseOpeningServiceTest
    {
        private readonly Mock<ICaseOpeningRepository> _mock;
        private readonly CaseOpeningService _service;
        
        public ICaseOpeningServiceTest()
        {
            _mock = new Mock<ICaseOpeningRepository>();
            _service = new CaseOpeningService(_mock.Object);
        }
        
        
        [Fact]
        public void ICaseOpeningService_IsAvailable()
        {
            Assert.NotNull(_service);
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
    }
}