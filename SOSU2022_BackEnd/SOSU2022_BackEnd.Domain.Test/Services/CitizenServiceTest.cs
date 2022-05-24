using System.Collections.Generic;
using System.IO;
using Moq;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BacEnd.Domain.Services;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.Core.Models;
using Xunit;

namespace SOSU2022_BackEnd.Domain.Services
{
    
         
    public class CitizenServiceTest
    {
        private readonly Mock<ICitizenRepository> _mock;
              private readonly CitizenService _service;
              private readonly List<Citizen> _expected;
              private readonly Citizen _expectedCit;
        
        public CitizenServiceTest()
        {
            _mock = new Mock<ICitizenRepository>();
            _service = new CitizenService(_mock.Object);
            _expected = new List<Citizen>();
            _expectedCit = new Citizen();
        }

        [Fact]
        public void CitizenService_IsICitizenService()
        {
            Assert.True(_service is ICitizenService);
        }

        [Fact]
        public void GetCitizenService_WithNullCitizenRepo_ThrowsInvalidDataEx()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new CitizenService(null));
            Assert.Equal("Repo cannot be null", exception.Message);
        }

        [Fact]
        public void GetAllCitizens_CallsCitizenRepo_OnlyOnce()
        {
            _service.GetAllCitizens();
            _mock.Verify(cr=> cr.GetCitizens(), Times.Once);
        }

        [Fact]
        public void Create_CallsCitizenService_OnlyOnce()
        {
            var ci = new Citizen
            {
                Id = "id", Age = 87, Name = "Bente"
            };
            _service.CreateCitizen(ci);
            _mock.Verify(cr => cr.Create(ci), Times.Once);
        }

        [Fact]
        public void Update_CallsCitizenRepo_OnlyOnce()
        {
            var ci = new Citizen
            {
                Id = "id", Age = 87, Name = "Bente"
            };
            _service.Update("idToUpdate", ci);
            _mock.Verify(cr => cr.Update("idToUpdate", ci), Times.Once);
        }

        [Fact]
        public void Delete_CallsCitizenRepo_OnlyOnce()
        {
            _service.Delete("idToDelete");
            _mock.Verify(cr => cr.Delete("idToDelete"), Times.Once);
        }

        [Fact]
        public void GetAll_NoParam_ReturnsListOfAllCitizens()
        {
            _mock.Setup(cr => cr.GetCitizens())
                .Returns(_expected);

            var actual = _service.GetAllCitizens();
            Assert.Equal(_expected, actual);
        }

        [Fact]
        public void Create_ReturnsCitizen()
        {
            var ci = new Citizen
            {
                Id = "id", Age = 87, Name = "Bente"
            };
            _mock.Setup(cr => cr.Create(ci))
                .Returns(_expectedCit);
        }

        [Fact]
        public void Update_ReturnsCitizen()
        {
            var ci = new Citizen
            {
                Id = "id", Age = 87, Name = "Bente"
            };
            _mock.Setup(cr => cr.Update("id", ci))
                .Returns(_expectedCit);
        }
        
    }
}