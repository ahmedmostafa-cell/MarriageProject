using MarriageProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarriageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormalUserApiController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public NormalUserApiController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        // GET: api/<NormalUserApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NormalUserApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NormalUserApiController>
        [HttpPost]
        public async Task<IActionResult> editImage([FromForm] EditUserViewModell editModel)
        {
            var result = await _accountRepository.EditUsersImage(editModel);

            if (result == null)
            {
                return BadRequest("the data is not saved");

            }
            return Ok("the data is saved");

        }

        // PUT api/<NormalUserApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NormalUserApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
