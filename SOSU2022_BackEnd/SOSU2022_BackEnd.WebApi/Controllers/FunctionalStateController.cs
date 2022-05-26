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
    public class FunctionalStateController : ControllerBase
    {
        private readonly IFunctionalStateService _functionalStateService;

        public FunctionalStateController(IFunctionalStateService functionalStateService)
        {
            _functionalStateService = functionalStateService ?? throw new InvalidDataException();
        }

        [HttpGet("{citizenId}")]
        public ActionResult<FunctionalStateDto[]> GetByCitizen(string citizenId,string subject)
        {
            try
            {
                return _functionalStateService.GetByCitizen(citizenId,subject)
                    .Select(f => new FunctionalStateDto
                    {

                    }).ToArray();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}