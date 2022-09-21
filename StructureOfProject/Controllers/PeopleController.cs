using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Serilog;
using StructureOfProject.DataAccessLayer.ApplicationDbContext.AppDbContext;
using StructureOfProject.DataAccessLayer.Repositories;
using StructureOfProject.Models;
using StructureOfProject.Services;

namespace StructureOfProject.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private IPeopleService _peopleService;


        public UserController(IServiceProvider serviceProvider,ILogger<UserController> logger)
        {
            _logger = logger;
            _peopleService = serviceProvider.GetRequiredService<PeopleApiService>();
        }

        [Route("GetInfoByName/{Name}")]
        [HttpGet]
        public string get(int Value, string Name)
        {
            //_logger.LogInformation("Hello !!_peopleService You are in the Controller!");
            //Log.Information("No one listens to me!");
            return "I am response from get controller" + " "+ Value + Name;
        }

        [Route("PostRoute")]
        [HttpPost]
        public string post( People people)
        {
            _logger.LogInformation("No one listens to me!");
            //Log.Information("No one listens to me!");
            return "I am response from post controller" ;
        }

        [Route("DividedByZero")]
        [HttpGet]
        public int sdfghjk()
        {
            int b = 3;
            int c = 0;
            int a = b / c;
            return c;
        }

        [HttpGet]
        public async Task<IEnumerable<People>> GetPeople()
        {
            throw new Exception("Exception while fetching all the students from the storage.");
            //throw new AccessViolationException("Violation Exception while accessing the resource.");
            var Detail = await _peopleService.GetPeopleAsync();
            return Detail;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<People>> GetPeopleByIdAsync(int id)
        {
            //Console.WriteLine("Hello");
            var peopleDetail = await _peopleService.GetByIdAsync(id);
            if (peopleDetail == null)
            {
                return NotFound();
            }
            return peopleDetail;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<People>> EditPeopleDetailAsync(int id, People peopleDetail)
        {
            
            People updatedOne = await _peopleService.UpdatepeopleAsync(id, peopleDetail);
            return updatedOne;
        }

        // POST: api/StudentDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<People>> PostPeopleDetailAsync(People peopleDetail)
        {
            if (_peopleService.AddpersonAsync == null)
            {
                return Problem("Entity set 'PeopleContext.PeopleDetails'  is null.");
            }
            People addedPerson = _peopleService.AddpersonAsync(peopleDetail).Result;
            return addedPerson;
        }


        // DELETE: api/StudentDetails/5
        [HttpDelete("{id}")]
        public async Task<string> DeletePeopleDetailAsync(int id)
        {
            if (_peopleService.DeleteAsync(id) == null)
            {
                return "This User does not exist";
            }
            var studentDetail = await _peopleService.DeleteAsync(id);
            await _peopleService.CompleteAsync();
            return studentDetail?"This User is deleted": "This user is not deleted";
        }
        //Ms test

        [Route("SearchByName/{Name}")]
        [HttpGet]
        public async Task<People> FirstOrDefaultAsync(string Name)
        {
            var detail = await _peopleService.FirstOrDefaultByNameAsync(x => x.Name == Name);
            return detail;
        }

        //[Route("Getallpeoples")]
        //[HttpGet]
        //public async Task<IEnumerable<People>> GetPeopleNameghj()
        //{
        //    //throw new Exception("Exception while fetching all the students from the storage.");
        //    //throw new AccessViolationException("Violation Exception while accessing the resource.");
        //    //var mockRepositories = new Mock<IPeopleRepositories>();
        //    //var mockRepositories = new PeopleRepositories();

        //    var repo = new PeopleRepositories(_context);
        //    var peopleApiService = new PeopleApiService(repo);
        //    var Detail = await peopleApiService.GetPeopleAsync();
            
        //    return Detail;
        //}
    }
}
