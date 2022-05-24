using System.Collections.Generic;
using Moq;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BacEnd.Domain.Services;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.Core.Models;
using Xunit;

namespace SOSU2022_BackEnd.Domain.Services
{
    public class GeneralInfoServiceTest
    {
        private readonly Mock<IGeneralInfoRepository> _mock;
        private readonly GeneralInfoService _service;
        private readonly List<GeneralInfo> _expected;
        private readonly GeneralInfo _expectedGeneralInfo;

        public GeneralInfoServiceTest()
        {
            _mock = new Mock<IGeneralInfoRepository>();
            _service = new GeneralInfoService(_mock.Object);
            _expected = new List<GeneralInfo>();
            _expectedGeneralInfo = new GeneralInfo();
        }

        [Fact]
        public void GeneralInfoService_IsIGeneralInfoService()
        {
            Assert.True(_service is IGeneralInfoService);
        }

        [Fact]
        public void GetGeneralInfoByCitizen_CallsGeneralInfoRepo_OnlyOnce()
        {
            _service.GetByCitizen("citizenId");
            _mock.Verify(gi => gi.GetByCitizen("citizenId"), Times.Once);
        }

        [Fact]
        public void Update_CallsGeneralInfoRepo_OnlyOnce()
        {
            var gi = new GeneralInfo
            {
                Id = "id", CitizenId = "CitizenId", Subject = "Mestring", Text = "TestTekst"
            };
            _service.UpdateGeneralInfo("generalToUpdate", gi);
            _mock.Verify(g => g.UpdateGeneralInformation("generalToUpdate", gi), Times.Once);
        }

        [Fact]
        public void GetInfo_WithParam_ReturnListOfGeneralInfo()
        {
            _mock.Setup(g => g.GetByCitizen("citizenId"))
                .Returns(_expected);

            var actual = _service.GetByCitizen("citizenId");
            Assert.Equal(_expected, actual);
        }

        [Fact]
        public void Update_ReturnsGeneralInfo()
        {
            var gi = new GeneralInfo
            {
                Id = "id", CitizenId = "CitizenId", Subject = "Mestring", Text = "TestTekst"
            };
            _mock.Setup(g => g.UpdateGeneralInformation("id", gi))
                .Returns(_expectedGeneralInfo);
        }
    }
}