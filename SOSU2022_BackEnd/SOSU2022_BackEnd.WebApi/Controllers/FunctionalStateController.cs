using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<FunctionalStateDto[]> GetByCitizen(string citizenId)
        {
            try
            {
                return _functionalStateService.GetByCitizen(citizenId)
                    .Select(f => new FunctionalStateDto
                    {
                        Overemne = f.Overemne,
                        Emne = f.Emne,
                        Subreading = f.Subreading,
                        NuværendeNiveau = f.NuværendeNiveau,
                        ForventetNiveau = f.ForventetNiveau,
                        FaligNotat = f.FaligNotat,
                        Udførelse = f.Udførelse,
                        Betydning = f.BetydningAfUdførelse,
                        ØnskerMål = f.ØnskerMål

                    }).ToArray();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}