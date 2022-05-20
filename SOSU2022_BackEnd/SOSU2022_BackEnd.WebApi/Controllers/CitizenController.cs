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
            try
            {
                var citizen = _citizenService.CreateCitizen(new Citizen
                {
                    Name = citizenDto.Name,
                    Age = citizenDto.Age
                });

                var citizenToReturn = new CitizenDto
                {
                    Name = citizen.Name,
                    Age = citizen.Age
                };

                return Created("https//:localhost/api/Citizen", citizenToReturn);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<CitizenDto[]> GetAllCitizen()
        {
            try
            {
                return _citizenService.GetAllCitizens()
                    .Select(c => new CitizenDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Age = c.Age
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
            try
            {
                var ci = _citizenService.Update(cToUpdate, new Citizen
                {
                    Name = citizenDto.Name,
                    Age = citizenDto.Age
                });

                var cDtoToReturn = new CitizenDto
                {
                    Name = ci.Name,
                    Age = ci.Age
                };
                return Ok(cDtoToReturn);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{cToDelete}")]
        public void DeleteCitizen(string cToDelete)
        {
            try
            {
                _citizenService.Delete(cToDelete);
            }
            catch (Exception e)
            {
                StatusCode(500, e.Message);
            }
        }
    }
}