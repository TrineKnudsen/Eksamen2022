using SOSU2022_BackEnd.Core.Models;
using SOSU2022_BackEnd.DataAcces.Documents;

namespace SOSU2022_BackEnd.DataAcces.Converters
{
    public class GeneralInformationConverter
    {
        public GeneralInfo Convert(GeneralInformationDocument document)
        {
            return new GeneralInfo
            {
                Id = document._id.ToString(),
                CitizenId = document.BorgerId,
                Subject = document.Emne,
                Text = document.Tekst
            };
        }

        public GeneralInformationDocument Convert(GeneralInfo model)
        {
            return new GeneralInformationDocument
            {
                BorgerId = model.CitizenId,
                Emne = model.Subject,
                Tekst = model.Text,
            };
        }
    }
}