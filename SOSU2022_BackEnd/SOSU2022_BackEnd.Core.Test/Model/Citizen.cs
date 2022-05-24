using System;
using SOSU2022_BackEnd.Core.Models;
using Xunit;

namespace SOSU2022_BackEnd.Core.Test
{
    public class CitizenTest
    {
        private readonly TestHelper _helper;

        public CitizenTest()
        {
            _helper = new TestHelper();
        }

        [Fact]
        public void Citizen_CanBeInitialized()
        {
            Assert.NotNull(_helper.GetCitizen());
        }

        [Fact]
        public void Citizen_SetId_StoresId()
        {
            var citizen = _helper.SetCitizen("citizenId");
            Assert.Equal("citizenId", citizen.Id);
        }
    }
}