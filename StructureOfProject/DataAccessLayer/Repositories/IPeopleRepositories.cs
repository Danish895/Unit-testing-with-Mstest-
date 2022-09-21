using StructureOfProject.Models;
using System.Linq.Expressions;

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
        Task<People> GetByNameAsync(Expression<Func<People, bool>> predicate);
    }
}
