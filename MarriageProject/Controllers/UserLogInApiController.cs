using MarriageProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarriageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogInApiController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public UserLogInApiController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromForm] SignUpModel signUpModel)
        {
            var result = await _accountRepository.SSignUpAsync(signUpModel);

            if (result == null)
            {
                return BadRequest("The Data is not saved");

            }
            return Ok("the data is saved");

        }


        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.LLoginAsync(signInModel);

            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }
        // GET: api/<UserLogInApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserLogInApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserLogInApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserLogInApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserLogInApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
