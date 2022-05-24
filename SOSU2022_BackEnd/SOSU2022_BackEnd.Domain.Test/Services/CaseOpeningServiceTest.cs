using System.Collections.Generic;
using System.IO;
using Moq;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BacEnd.Domain.Services;
using SOSU2022_BackEnd.Core.IServices;
using Xunit;

namespace SOSU2022_BackEnd.Domain.Services
{
    public class CaseOpeningServiceTest
    {
        private readonly Mock<ICaseOpeningRepository> _mock;
        private readonly CaseOpeningService _service;
        private readonly List<CaseOpening> _expected;
        private readonly CaseOpening _expectedCase;

        public CaseOpeningServiceTest()
        {
            _mock = new Mock<ICaseOpeningRepository>();
            _service = new CaseOpeningService(_mock.Object);
            _expected = new List<CaseOpening>();
            _expectedCase = new CaseOpening();
        }

        [Fact]
        public void CaseOpeningService_IsICaseOpeningService()
        {
            Assert.True(_service is ICaseOpeningService);
        }

        [Fact]
        public void CaseOpeningService_WithNullCaseOpeningRepo_ThrowsInvalidDataEx()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new CaseOpeningService(null));
            Assert.Equal("Repo cannot be null", exception.Message);
        }

        [Fact]
        public void GetCaseOpening_CallsCaseOpeningRepo_OnlyOnce()
        {
            _service.GetAll();
            _mock.Verify(g => g.GetAll(), Times.Once);
        }

        [Fact]
        public void GetCaseOpeningByCitizen_CallsCaseOpeningRepo_OnlyOnce()
        {
            _service.GetByCitizen("citizenId");
            _mock.Verify(g => g.GetByCitizen("citizenId"), Times.Once);
        }

        [Fact]
        public void DeleteCitizen_CallsCaseOpeningRepo_OnlyOnce()
        {
            _service.Delete("citizenId");
            _mock.Verify(g => g.Delete("citizenId"), Times.Once);
        }

        [Fact]
        public void Update_CallsCaseOpeningRepo_OnlyOnce()
        {
            var co = new CaseOpening
            {
                Id = "id", CitizenId = "CitizenId", Reference = "læge", Summary = "korttest"
            };
            _service.Update("idToUpdate", co);
            _mock.Verify(r => r.Update("idToUpdate", co), Times.Once);
        }

        [Fact]
        public void Create_CallsCaseOpeningRepo_OnlyOnce()
        {
            var co = new CaseOpening
            {
                Id = "id", CitizenId = "CitizenId", Reference = "læge", Summary = "korttest"
            };
            _service.Create(co);
            _mock.Verify(r => r.Create(co), Times.Once);
        }

        [Fact]
        public void GetAll_NoParam_ReturnsListOfAllCaseOpenings()
        {
            _mock.Setup(r => r.GetAll())
                .Returns(_expected);

            var actual = _service.GetAll();
            Assert.Equal(_expected, actual);
        }

        [Fact]
        public void GetAll_WithParam_ReturnListOfCaseOpening()
        {
            _mock.Setup(r => r.GetByCitizen("citizenId"))
                .Returns(_expected);
            var actual = _service.GetByCitizen("citizenId");
            Assert.Equal(_expected,actual);
        }

        [Fact]
        public void Create_ReturnCaseOpening()
        {
            var co = new CaseOpening
            {
                Id = "id", CitizenId = "CitizenId", Reference = "læge", Summary = "korttest"
            };
            _mock.Setup(r => r.Create(co)).Returns(_expectedCase);
        }

        [Fact]
        public void Update_ReturnsCaseOpening()
        {
            var co = new CaseOpening
            {
                Id = "id", CitizenId = "CitizenId", Reference = "læge", Summary = "korttest"
            };
            _mock.Setup(r => r.Update("id", co)).Returns(_expectedCase);
        }
    }
}