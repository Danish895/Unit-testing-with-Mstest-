using StructureOfProject.DataAccessLayer.Repositories;
using StructureOfProject.Models;
using System.Linq.Expressions;

namespace StructureOfProject.Services
{
    public class PeopleApiService : PeopleService 
    {
        public PeopleApiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async override Task<People> FirstOrDefaultByNameAsync(Expression<Func<People, bool>> predicate)
        {
            var detail = await _peopleRepositories.GetByNameAsync(predicate);
            return detail;
        }
    }
}
