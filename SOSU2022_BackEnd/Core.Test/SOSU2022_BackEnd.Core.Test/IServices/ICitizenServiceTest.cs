using System.Collections.Generic;
using System.IO;
using SOSU2022_BackEnd.Core.IServices;
using Moq;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BacEnd.Domain.Services;
using SOSU2022_BackEnd.Core.Models;
using Xunit;

namespace SOSU2022_BackEnd.Core.Test.IServices
{
    public class ICitizenServiceTest
    {
        private readonly Mock<ICitizenRepository> _mock;
        private readonly CitizenService _service;

        public ICitizenServiceTest()
        {
            _mock = new Mock<ICitizenRepository>();
            _service = new CitizenService(_mock.Object);
        }
        
        [Fact]
        public void ICitizenService_IsAvailable()
        {
            var service = new Mock<ICitizenService>().Object;
            Assert.NotNull(service);
        }

        [Fact]
        public void CitizenService_IsICitizenService()
        {
            Assert.True(_service is ICitizenService);
        }

        [Fact]
        public void CitizenService_WithNullCitizenRepo_ThrowsInvalidDataException()
        {
            
        }

        [Fact]
        public void GetCitizens_withoutParams_ReturnsListOfAllCitizens()
        {
            var mock = new Mock<ICitizenService>();
            var fakelist = new List<Citizen>();
            mock.Setup(s => s.GetAllCitizens())
                .Returns(fakelist);
            var service = mock.Object;
            Assert.Equal(fakelist,service.GetAllCitizens());
        }
    }
}