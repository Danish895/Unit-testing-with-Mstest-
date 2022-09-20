﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
        

        public UserController(ILogger<UserController> logger, IPeopleService peopleService)
        {
            _logger = logger;
            _peopleService = peopleService;
        }

        [Route("GetInfoByName/{Name}")]
        [HttpGet]
        public string get(int Value, string Name)
        {
            _logger.LogInformation("Hello !!_peopleService You are in the Controller!");
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

        [HttpGet]
        public async Task<IEnumerable<People>> GetPeople()
        {
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
        public async Task<IActionResult> EditPeopleDetailAsync(int id, People peopleDetail)
        {

            await _peopleService.UpdatepeopleAsync(id, peopleDetail);
            await _peopleService.CompleteAsync();
            return Ok();
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
            _peopleService.AddpersonAsync(peopleDetail);
            
            _peopleService.CompleteAsync();

            return Ok();
        }


        // DELETE: api/StudentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<People>> DeletePeopleDetailAsync(int id)
        {
            if (_peopleService.DeleteAsync(id) == null)
            {
                return NotFound();
            }
            var studentDetail = await _peopleService.DeleteAsync(id);
            await _peopleService.CompleteAsync();
            return Ok(studentDetail);
        }
        //Ms test
    }
}