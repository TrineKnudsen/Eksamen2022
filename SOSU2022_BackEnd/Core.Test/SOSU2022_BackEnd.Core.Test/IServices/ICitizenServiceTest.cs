using System.Collections.Generic;
using SOSU2022_BackEnd.Core.IServices;
using Moq;
using SOSU2022_BackEnd.Core.Models;
using Xunit;

namespace SOSU2022_BackEnd.Core.Test.IServices
{
    public class ICitizenServiceTest
    {
        [Fact]
        public void ICitizenService_IsAvailable()
        {
            var service = new Mock<ICitizenService>().Object;
            Assert.NotNull(service);
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