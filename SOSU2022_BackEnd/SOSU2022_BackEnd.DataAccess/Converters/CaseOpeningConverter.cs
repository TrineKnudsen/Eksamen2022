using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.DataAcces.Documents;

namespace SOSU2022_BackEnd.DataAcces.Converters
{
    public class CaseOpeningConverter
    {
        public CaseOpening Convert(CaseOpeningDocument document)
        {
            return new CaseOpening()
            {
                Id = document._id.ToString(),
                CitizenId = document.BorgerId,
                Summary = document.Fritekst,
                Reference = document.Henvisning,
            };
        }

        public CaseOpeningDocument Convert(CaseOpening model)
        {
            return new CaseOpeningDocument
            {
                BorgerId = model.CitizenId,
                Fritekst = model.Summary,
                Henvisning = model.Reference,
            };
        }
    }
}