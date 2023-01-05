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
        NormalUserService normalUserService;
        InitiativeRegisteredUserService initiativeRegisteredUserService;
        public HomeController(InitiativeRegisteredUserService  InitiativeRegisteredUserService,NormalUserService NormalUserService,InitiativeRegisteredFamilyMemberService InitiativeRegisteredFamilyMemberService, MarriagedDbContext context)
        {
            normalUserService = NormalUserService;
            ctx = context;
            initiativeRegisteredFamilyMemberService = InitiativeRegisteredFamilyMemberService;
            initiativeRegisteredUserService = InitiativeRegisteredUserService;
        }
        public IActionResult Index()
        {
            ViewBag.NormalUsers = normalUserService.getAll().Count;
            ViewBag.InitiativeRegisteredUser = initiativeRegisteredUserService.getAll().Count;
            ViewBag.InitiativeRegisteredFamilyMember = initiativeRegisteredFamilyMemberService.getAll().Count;
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
