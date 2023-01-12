using BL;
using BL.Migrations;
using Domains;
using MarriageProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarriageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainsAndSuggestionApiController : ControllerBase
    {
        MarriagedDbContext Ctx;
        UserManager<ApplicationUser> Usermanager;
        private readonly IAccountRepository _accountRepository;
        public ComplainsAndSuggestionApiController(MarriagedDbContext context,UserManager<ApplicationUser> usermanager, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            Usermanager = usermanager;
            Ctx = context;
        }
        // GET: api/<ComplainsAndSuggestionApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ComplainsAndSuggestionApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ComplainsAndSuggestionApiController>
        [HttpPost("SendComplain")]
        public IActionResult Post([FromForm] ComplainsAndSuggestionViewModel sendComplainModel)
        {
            TbComplainsAndSuggestion oTbComplain = new TbComplainsAndSuggestion();
            oTbComplain.ComplaintsAndSuggestionsId = Guid.NewGuid();
            oTbComplain.Id = sendComplainModel.Id;
            oTbComplain.Name = sendComplainModel.Name;
            oTbComplain.ComplaintsAndSuggestionsText = sendComplainModel.ComplaintsAndSuggestionsText;
            oTbComplain.CreatedDate = DateTime.Now;
            Ctx.TbComplainsAndSuggestions.Add(oTbComplain);
            var result = Ctx.SaveChanges();
            if(result == 1) 
            {
                return Ok("the complaain is sent");

            }
            else 
            {
                return BadRequest("the complain has not been sent");
            }
           
            
        }

        // PUT api/<ComplainsAndSuggestionApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ComplainsAndSuggestionApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
