using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StructureOfProject.DataAccessLayer.ApplicationDbContext.AppDbContext;
using StructureOfProject.Models;


namespace StructureOfProject.DataAccessLayer.Repositories
{
    public class PeopleRepositories :  IPeopleRepositories
    {
        private AppDbContext _context;
        public PeopleRepositories(AppDbContext context)
        {
            _context = context;
        }

        

        public async Task<IEnumerable<People>> GetPeopleAsync()
        {
             List<People> peoples = await _context.Peoples.ToListAsync();
             return peoples;
        }

        public async Task<People> GetByIdAsync(int id)
        {
            return await _context.Peoples.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            People personToBeDeleted = await _context.Peoples.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Peoples.Remove(personToBeDeleted);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<People> AddpersonAsync(People peopleDetail)
        {
            _context.Peoples.Add(peopleDetail);
            await _context.SaveChangesAsync();
            return await _context.Peoples.FindAsync(peopleDetail.Id);

        }
        public async Task<People> UpdatepeopleAsync(int id, People personDetail)
        {
            People personToBeUpdated = await _context.Peoples.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (personDetail.Name != null) { personToBeUpdated.Name = personDetail.Name.Trim(); }
            
            await _context.SaveChangesAsync();
            return await _context.Peoples.FindAsync(id);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
