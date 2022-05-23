using System;
using SOSU2022_BackEnd.Core.Models;
using Xunit;

namespace SOSU2022_Backend.Domain.Test
{
    public class CitizenTest
    {
        private readonly Citizen _citizen;

        public CitizenTest()
        {
            _citizen = new Citizen();
        }

        [Fact]
        public void Citizen_CanBeInitialized()
        {
            Assert.NotNull(_citizen);
        }
    }
}