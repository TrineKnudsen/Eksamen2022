using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.Core.Models;
using SOSU2022_BackEnd.DTOs;

namespace SOSU2022_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private readonly ICitizenService _citizenService;

        public CitizenController(ICitizenService citizenController)
        {
            _citizenService = citizenController ?? throw new InvalidDataException();
        }

        [HttpPost]
        public ActionResult<CitizenDto> CreateCitizen([FromBody] CitizenDto citizenDto)
        {
            var citizen = _citizenService.CreateCitizen(new Citizen
            {
                Navn = citizenDto.Navn,
                Alder = citizenDto.Alder
            });

            var citizenToReturn = new CitizenDto
            {
                Navn = citizen.Navn,
                Alder = citizen.Alder
            };

            return Created("https//:localhost/api/citizen", citizenToReturn);
        }

        [HttpGet]
        public ActionResult<CitizenDto[]> GetAllCitizen()
        {
            try
            {
                return _citizenService.GetAllCitizens()
                    .Select(c => new CitizenDto
                    {
                        Navn = c.Navn,
                        Alder = c.Alder
                    }).ToArray();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch("{cToUpdate}")]
        public ActionResult<CitizenDto> UpdateCitizenDto(string cToUpdate, [FromBody] CitizenDto citizenDto)
        {
            var ci = _citizenService.Update(cToUpdate, new Citizen
            {
                Navn = citizenDto.Navn,
                Alder = citizenDto.Alder
            });

            var cDtoToReturn = new CitizenDto
            {
                Navn = ci.Navn,
                Alder = ci.Alder
            };
            return Ok(cDtoToReturn);
        }

        [HttpDelete("{cToDelete}")]
        public void DeleteCitizen(string cToDelete, [FromBody] CitizenDto citizenDto)
        {
            _citizenService.Delete(cToDelete);
        }
    }
}