using BL;
using MarriageProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarriageProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        InitiativeRegisteredFamilyMemberService initiativeRegisteredFamilyMemberService;
        MarriagedDbContext ctx;

        public HomeController(InitiativeRegisteredFamilyMemberService InitiativeRegisteredFamilyMemberService, MarriagedDbContext context)
        {

            ctx = context;
            initiativeRegisteredFamilyMemberService = InitiativeRegisteredFamilyMemberService;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegiteredUserwithMembers()
        {
            HomePageModel model = new HomePageModel();
            model.lVwRegisteredUser = ctx.VwRegisteredUsers;
            return View(model);
        }



        
    }
}
