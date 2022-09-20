using StructureOfProject.DataAccessLayer.ApplicationDbContext.AppDbContext;
using StructureOfProject.DataAccessLayer.Repositories;
using StructureOfProject.Models;

namespace StructureOfProject.Services
{
    public class PeopleService : IPeopleService
    {
        private IPeopleRepositories _peopleRepositories;


        public PeopleService(IPeopleRepositories peopleRepositories)
        {
            _peopleRepositories = peopleRepositories;
        }

        public async Task<IEnumerable<People>> GetPeopleAsync()
        {
            var detail = await _peopleRepositories.GetPeopleAsync();
            return detail;
        }
        public async Task<People> GetByIdAsync(int id)
        {
            Console.WriteLine("Hello");
            var detail = await _peopleRepositories.GetByIdAsync(id);
            return detail;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var detail = await _peopleRepositories.DeleteAsync(id);
            return true;
        }

        public async Task<People> AddpersonAsync(People peopleDetail)
        {
            var detail = await _peopleRepositories.AddpersonAsync(peopleDetail);
            return detail;
        }
        public async Task<People> UpdatepeopleAsync(int id, People peopleDetail)
        {
            var detail = await _peopleRepositories.UpdatepeopleAsync(id, peopleDetail);
            return detail;
        }

        public async Task CompleteAsync()
        {
            await _peopleRepositories.CompleteAsync();
        }

    }
}
