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
            try
            {
                var co = _caseOpeningService.Create(new CaseOpening
                {
                    CitizenId = caseOpeningDto.CitizenId,
                    Reference = caseOpeningDto.Reference,
                    Summary = caseOpeningDto.Summary,
                });

                var dtoToReturn = new CaseOpeningDto
                {
                    CitizenId = co.CitizenId,
                    Reference = co.Reference,
                    Summary = co.Summary,
                };

                return Created("https//:localhost/api/CaseOpening", dtoToReturn);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public ActionResult<CaseOpeningDto[]> GetAllCaseOpenings()
        {
            try
            {
                return _caseOpeningService.GetAll()
                    .Select(co => new CaseOpeningDto
                    {
                        Id = co.Id,
                        CitizenId = co.CitizenId,
                        Reference = co.Reference,
                        Summary = co.Summary,
                    }).ToArray();
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
                    .Select(co => new CaseOpeningDto
                    {
                        Id = co.Id,
                        CitizenId = co.CitizenId,
                        Reference = co.Reference,
                        Summary = co.Summary,
                    }).ToArray();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch("{coToUpdate}")]
        public ActionResult<CaseOpeningDto> UpdateCaseOpeningDto(string coToUpdate,
            [FromBody] CaseOpeningDto caseOpeningDto)
        {
            try
            {
                var co = _caseOpeningService.Update(coToUpdate, new CaseOpening
                {
                    Id = caseOpeningDto.Id,
                    CitizenId = coToUpdate,
                    Reference = caseOpeningDto.Reference,
                    Summary = caseOpeningDto.Summary,
                });

                var coDtoToReturn = new CaseOpeningDto
                {
                    Id = co.Id,
                    CitizenId = co.CitizenId,
                    Reference = co.Reference,
                    Summary = co.Summary,
                };
                return Ok(coDtoToReturn);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{coToDelete}")]
        public void DeleteCaseOpening(string coToDelete)
        {
            try
            {
                _caseOpeningService.Delete(coToDelete);
            }
            catch (Exception e)
            {
                StatusCode(500, e.Message);
            }
        }
    }
}