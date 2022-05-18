using System;

namespace SOSU2022_BackEnd.Core.Models
{
    public class FunctionalState : CaseInformation
    {
        public string Subreading { get; set; }
        public int NuværendeNiveau { get; set; }
        public int ForventetNiveau { get; set; }
        public string FaligNotat { get; set; }
        public string Udførelse { get; set; }
        public bool BetydningAfUdførelse { get; set; }
        public string ØnskerMål { get; set; }
    }
}