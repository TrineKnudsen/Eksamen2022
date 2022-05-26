using System;

namespace SOSU2022_BackEnd.Core.Models
{
    public class FunctionalState
    {
        public string Id { get; set; }
        public string BorgerId { get; set; }
        public string Subject { get; set; }
        public int Selfcare { get; set; }
        public int Bodycare { get; set; }
    }
}