using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.Core.Models;
using SOSU2022_BackEnd.DTOs;

namespace SOSU2022_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralInfoController : ControllerBase
    {
        private readonly IGeneralInfoService _generalInfoService;

        public GeneralInfoController(IGeneralInfoService generalInfoService)
        {
            _generalInfoService = generalInfoService ?? throw new InvalidDataException();
        }

        [HttpGet("{citizenId}")]
        public ActionResult<GeneralInfoDto[]> GetByCitizen(string citizenId)
        {
            try
            {
                return _generalInfoService.GetByCitizen(citizenId)
                    .Select(g => new GeneralInfoDto
                    {
                        Id = g.Id,
                        CitizenId = g.CitizenId,
                        Subject = g.Subject,
                        Text = g.Text,
                    }).ToArray();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{generalToUpdate}")]
        public ActionResult<GeneralInfoDto> UpdateGeneralInformation(string generalToUpdate,
            [FromBody] UpdateGeneralInformationDto updatedGeneral)
        {
            try
            {
                var updatedModel = _generalInfoService.UpdateGeneralInfo(generalToUpdate,
                    new GeneralInfo
                    {
                        Text = updatedGeneral.Text
                    });

                var dtoToReturn = new GeneralInfoDto
                {
                    Id = updatedModel.Id,
                    CitizenId = updatedModel.CitizenId,
                    Subject = updatedModel.Subject,
                    Text = updatedGeneral.Text
                };
                return Ok(dtoToReturn);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}