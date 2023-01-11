using BL;
using MarriageProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarriageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogInApiController : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        private readonly IAccountRepository _accountRepository;
        public UserLogInApiController(UserManager<ApplicationUser> usermanager, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            Usermanager = usermanager;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromForm] SignUpModel signUpModel)
        {
            var result = await _accountRepository.SSignUpAsync(signUpModel);

            if (result != "Succeeded")
            {
                return BadRequest(result);

            }
            else
            {
                ApplicationUser user = await Usermanager.FindByEmailAsync(signUpModel.Email);

                return Ok(user);

            }

        }


        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.LLoginAsync(signInModel);

            if (result == "Failed")
            {
                return BadRequest(result);
            }
            else 
            {
                ApplicationUser user = await Usermanager.FindByEmailAsync(signInModel.Email);

                return Ok(user);

            } 

           
        }
        // GET: api/<UserLogInApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserLogInApiController>/5
        [HttpGet("{id}")]
        public ApplicationUser Get(string id)
        {
            return Usermanager.Users.Where(a => a.Id == id).FirstOrDefault();
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
