using BL;
using Domains;
using MarriageProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarriageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitiativeRegisteredUserApiController : ControllerBase
    {
        UserManager<ApplicationUser> Usermanager;
        private readonly IAccountRepository _accountRepository;
        InitiativeRegisteredUserService initiativeRegisteredUserService;
        InitiativeRegisteredFamilyMemberService initiativeRegisteredFamilyMemberService;
        MarriagedDbContext ctx;
        public InitiativeRegisteredUserApiController(UserManager<ApplicationUser> usermanager, IAccountRepository accountRepository,InitiativeRegisteredFamilyMemberService InitiativeRegisteredFamilyMemberService,MarriagedDbContext context , InitiativeRegisteredUserService InitiativeRegisteredUserService)
        {
            initiativeRegisteredUserService = InitiativeRegisteredUserService;
            ctx = context;
            initiativeRegisteredFamilyMemberService = InitiativeRegisteredFamilyMemberService;
            _accountRepository = accountRepository;
            Usermanager = usermanager;


        }
        // GET: api/<InitiativeRegisteredUserApiController>
        [HttpGet]
        public IEnumerable<ApplicationUser> Get()
        {
            return Usermanager.Users.ToList().Where(a => a.Status == "Initiative Registered User");
        }

        // GET api/<InitiativeRegisteredUserApiController>/5
        [HttpGet("{id}")]
        public IEnumerable<VwRegisteredUser2> Get2(string Id)
        {
            var a = ctx.VwRegisteredUsers2.Where(a => a.Id == Id).ToList();
            //var a = ctx.VwRegisteredUsers.ToList();
            return a;
        }

        // POST api/<InitiativeRegisteredUserApiController>
        [HttpPost("registeruser")]
        public async Task<IActionResult> PostAsync([FromBody] InitiativeRegisteredViewPageModel services)
        {
         

            TbInitiativeRegisteredUser oTbInitiativeRegisteredUser = new TbInitiativeRegisteredUser();

            oTbInitiativeRegisteredUser.InitiativeRegisteredUserName = services.InitiativeRegisteredUserName;
            oTbInitiativeRegisteredUser.InitiativeRegisteredUserFamilyName = services.InitiativeRegisteredUserFamilyName;
            oTbInitiativeRegisteredUser.InitiativeRegisteredUserAge = services.InitiativeRegisteredUserAge;
            oTbInitiativeRegisteredUser.InitiativeRegisteredUserPhoneNo = services.InitiativeRegisteredUserPhoneNo;
            initiativeRegisteredUserService.Add(oTbInitiativeRegisteredUser);
           
            foreach (var i in services.Names)
            {
                TbInitiativeRegisteredFamilyMember oTbInitiativeRegisteredFamilyMember = new TbInitiativeRegisteredFamilyMember();
                oTbInitiativeRegisteredFamilyMember.InitiativeRegisteredFamilyMemberName = i.name;
                oTbInitiativeRegisteredFamilyMember.InitiativeRegisteredFamilyMemberBirthDate = i.birthdate;
                oTbInitiativeRegisteredFamilyMember.InitiativeRegisteredUserId = oTbInitiativeRegisteredUser.InitiativeRegisteredUserId;
                initiativeRegisteredFamilyMemberService.Add(oTbInitiativeRegisteredFamilyMember);
                
                

            }
            
            return Ok("services required is added");

        }





        [HttpPost("registeruser2")]
        public async Task<IActionResult> Post2Async([FromBody] InitiativeRegisteredViewPageModel services)
        {
            var result = await _accountRepository.EditUsers(services);

            if (result != "Succeeded")
            {
                return BadRequest(result);

            }
            else
            {
                ApplicationUser user = await Usermanager.FindByIdAsync(services.Id);

               
                foreach (var i in services.Names)
                {
                    TbInitiativeRegisteredFamilyMember oTbInitiativeRegisteredFamilyMember = new TbInitiativeRegisteredFamilyMember();
                    oTbInitiativeRegisteredFamilyMember.InitiativeRegisteredFamilyMemberName = i.name;
                    oTbInitiativeRegisteredFamilyMember.InitiativeRegisteredFamilyMemberBirthDate = i.birthdate;
                    oTbInitiativeRegisteredFamilyMember.InitiativeRegisteredUserId = Guid.Parse(services.Id);
                    initiativeRegisteredFamilyMemberService.Add(oTbInitiativeRegisteredFamilyMember);



                }
                return Ok(user);

            }

           

           

        }

        // PUT api/<InitiativeRegisteredUserApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InitiativeRegisteredUserApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
