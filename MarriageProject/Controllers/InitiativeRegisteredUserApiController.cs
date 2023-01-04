using BL;
using Domains;
using MarriageProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarriageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitiativeRegisteredUserApiController : ControllerBase
    {
        InitiativeRegisteredUserService initiativeRegisteredUserService;
        InitiativeRegisteredFamilyMemberService initiativeRegisteredFamilyMemberService;
        MarriagedDbContext ctx;
        public InitiativeRegisteredUserApiController(InitiativeRegisteredFamilyMemberService InitiativeRegisteredFamilyMemberService,MarriagedDbContext context , InitiativeRegisteredUserService InitiativeRegisteredUserService)
        {
            initiativeRegisteredUserService = InitiativeRegisteredUserService;
            ctx = context;
            initiativeRegisteredFamilyMemberService = InitiativeRegisteredFamilyMemberService;


        }
        // GET: api/<InitiativeRegisteredUserApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InitiativeRegisteredUserApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
