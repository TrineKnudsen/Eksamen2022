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
                Name = citizenDto.Name
            });

            var citizenToReturn = new CitizenDto
            {
                Name = citizen.Name
            };

            return Created("https//:localhost/api/citizen", citizenToReturn);
        }

        [HttpGet]
        public ActionResult<CitizenDtos> GetAllCitizen()
        {
            try
            {
                var citizens = _citizenService.GetAllCitizens()
                    .Select(c => new CitizenDto
                    {
                        Name = c.Name
                    }).ToList();

                return Ok(new CitizenDtos
                {
                    List = citizens
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}