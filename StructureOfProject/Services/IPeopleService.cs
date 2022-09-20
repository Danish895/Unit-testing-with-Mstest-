using StructureOfProject.Models;

namespace StructureOfProject.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> GetPeopleAsync();
        Task<People> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<People> AddpersonAsync(People people);
        Task<People> UpdatepeopleAsync(int id, People people);
        Task CompleteAsync();
        
    }
}
