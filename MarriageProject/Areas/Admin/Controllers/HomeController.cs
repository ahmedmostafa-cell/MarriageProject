using BL;
using MarriageProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MarriageProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        UserManager<ApplicationUser> Usermanager;
        InitiativeRegisteredFamilyMemberService initiativeRegisteredFamilyMemberService;
        MarriagedDbContext ctx;
        NormalUserService normalUserService;
        InitiativeRegisteredUserService initiativeRegisteredUserService;
        public HomeController(UserManager<ApplicationUser> usermanager, InitiativeRegisteredUserService  InitiativeRegisteredUserService,NormalUserService NormalUserService,InitiativeRegisteredFamilyMemberService InitiativeRegisteredFamilyMemberService, MarriagedDbContext context)
        {
            normalUserService = NormalUserService;
            ctx = context;
            initiativeRegisteredFamilyMemberService = InitiativeRegisteredFamilyMemberService;
            initiativeRegisteredUserService = InitiativeRegisteredUserService;
            Usermanager = usermanager;
        }
        public IActionResult Index()
        {
            ViewBag.NormalUsers = Usermanager.Users.Where(a => a.Status == "Normal User").ToList().Count;
            ViewBag.InitiativeRegisteredUser = Usermanager.Users.Where(a => a.Status == "Initiative Registered User").ToList().Count;
            ViewBag.InitiativeRegisteredFamilyMember = initiativeRegisteredFamilyMemberService.getAll().Count;
            return View();
        }
        public IActionResult RegiteredUserwithMembers()
        {
            HomePageModel model = new HomePageModel();
            model.lVwRegisteredUser2 = ctx.VwRegisteredUsers2;
            return View(model);
        }
        public IActionResult ComplainsAndSuggestion()
        {
            HomePageModel model = new HomePageModel();
            model.lstComplainsAndSuggestions = ctx.TbComplainsAndSuggestions.ToList();
            return View(model);
        }

        

    }
}
