using BL;
using Domains;
using MarriageProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarriageProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderApiController : ControllerBase
    {
        InitiativeRegisteredUserService initiativeRegisteredUserService;
        SliderService sliderService;
        InitiativeRegisteredFamilyMemberService initiativeRegisteredFamilyMemberService;
        MarriagedDbContext ctx;
        public SliderApiController(SliderService SliderService,InitiativeRegisteredFamilyMemberService InitiativeRegisteredFamilyMemberService, MarriagedDbContext context, InitiativeRegisteredUserService InitiativeRegisteredUserService)
        {
            initiativeRegisteredUserService = InitiativeRegisteredUserService;
            ctx = context;
            initiativeRegisteredFamilyMemberService = InitiativeRegisteredFamilyMemberService;
            sliderService = SliderService;

        }
        // GET: api/<SliderApiController>
        [HttpGet]
        public IEnumerable<TbSlider> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstSliders = sliderService.getAll();
            return model.lstSliders;
        }

        // GET api/<SliderApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SliderApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SliderApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SliderApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
