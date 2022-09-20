using StructureOfProject.Models;

namespace StructureOfProject.DataAccessLayer.Repositories
{
    public interface IPeopleRepositories
    {
        Task<IEnumerable<People>> GetPeopleAsync();
        Task<People> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<People> AddpersonAsync(People people);
        Task<People> UpdatepeopleAsync(int id, People people);
        Task CompleteAsync();
    }
}
