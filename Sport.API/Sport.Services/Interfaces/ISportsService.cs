using Sport.Models.DTOModels.Articles;
using Sport.Models.Entities;

namespace Sport.Services.Interfaces
{
    public interface ISportsService
    {
        public Task<List<SportsDTO>> GetSportTypes();

        public string GetDescription(SportType GenericEnum);
    }
}
