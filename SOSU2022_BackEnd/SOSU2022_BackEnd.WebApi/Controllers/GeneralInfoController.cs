using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SOSU2022_BackEnd.Core.IServices;
using SOSU2022_BackEnd.DTOs;

namespace SOSU2022_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralInfoController : ControllerBase
    {
        private readonly IGeneralInfoService _generalInfoService;

        public GeneralInfoController(IGeneralInfoService GeneralInfoService)
        {
            _generalInfoService = GeneralInfoService ?? throw new InvalidDataException();
        }

        [HttpGet("{citizenId}")]
        public ActionResult<GeneralInfoDto[]> GetByCitizen(string citizenId)
        {
            try
            {
                return _generalInfoService.GetByCitizen(citizenId)
                    .Select(g => new GeneralInfoDto
                    {
                        Overemne = g.Overemne,
                        Emne = g.Emne,
                        Hjaelp = g.Hjaelp,
                        Tekst = g.Tekst,
                    }).ToArray();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}