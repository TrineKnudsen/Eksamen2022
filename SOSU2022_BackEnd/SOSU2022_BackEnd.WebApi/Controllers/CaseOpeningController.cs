using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.DTOs;

namespace SOSU2022_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseOpeningController : ControllerBase
    {
        private readonly ICaseOpeningService _caseOpeningService;

        public CaseOpeningController(ICaseOpeningService caseOpeningService)
        {
            _caseOpeningService = caseOpeningService ?? throw new InvalidDataException();
        }

        [HttpPost]
        public ActionResult<CaseOpeningDto> CreateCaseOpening([FromBody] CaseOpeningDto caseOpeningDto)
        {
            var co = _caseOpeningService.Create(new CaseOpening
            {
                Henvisning = caseOpeningDto.Henvisning,
                Fritekst = caseOpeningDto.Fritekst,
            });

            var dtoToReturn = new CaseOpeningDto
            {
                Henvisning = co.Henvisning,
                Fritekst = co.Fritekst,
            };

            return Created("https//:localhost/api/CaseOpening", caseOpeningDto);
        }

        [HttpGet]
        public ActionResult<List<CaseOpening>> GetAllCaseOpenings()
        {
            try
            {
                var cos = _caseOpeningService.GetAll()
                    .Select(c => new CaseOpeningDto
                    {
                        Id = c._id,
                        BorgerId = c.BorgerId,
                        Fritekst = c.Fritekst,
                        Henvisning = c.Fritekst
                    }).ToList();

                return Ok(new CaseOpeningDtos
                {
                    List = cos
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{citizenId}")]
        public ActionResult<CaseOpeningDto[]> GetByCitizen(string citizenId)
        {
            try
            {
                return _caseOpeningService.GetByCitizen(citizenId)
                    .Select(c => new CaseOpeningDto
                    {
                        Henvisning = c.Henvisning,
                        Fritekst = c.Fritekst
                    }).ToArray();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch("{coToUpdate}")]
        public ActionResult<CaseOpeningDto> UpdateCaseOpeningDto(string coToUpdate, [FromBody] CaseOpeningDto caseOpeningDto)
        {
            var co = _caseOpeningService.Update(coToUpdate, new CaseOpening
            {
                Henvisning = caseOpeningDto.Henvisning,
                Fritekst = caseOpeningDto.Fritekst,
            });

            var coDtoToReturn = new CaseOpeningDto
            {
                Henvisning = co.Henvisning,
                Fritekst = co.Fritekst,
            };
            return Ok(coDtoToReturn);
        }

        [HttpDelete("{coToDelete}")]
        public void DeleteCaseOpening(string coToDelete, [FromBody] CaseOpeningDto caseOpeningDto)
        {
            _caseOpeningService.Delete(coToDelete);
        }
    }
}