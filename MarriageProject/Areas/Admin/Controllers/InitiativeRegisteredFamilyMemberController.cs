using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using MarriageProject.Models;
using Domains;
using System.Linq;

namespace MarriageProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InitiativeRegisteredFamilyMemberController : Controller
    {
        InitiativeRegisteredFamilyMemberService initiativeRegisteredFamilyMemberService;
        MarriagedDbContext ctx;
        
        public InitiativeRegisteredFamilyMemberController(InitiativeRegisteredFamilyMemberService InitiativeRegisteredFamilyMemberService, MarriagedDbContext context)
        {

            ctx = context;
            initiativeRegisteredFamilyMemberService = InitiativeRegisteredFamilyMemberService;
            
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbInitiativeRegisteredFamilyMember ITEM, List<IFormFile> files)
        {


            if (ITEM.InitiativeRegisteredFamilyMemberId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.InitiativeRegisteredFamilyMemberImage = ImageName;
                    }
                }


                var result = initiativeRegisteredFamilyMemberService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "InitiativeRegisteredFamilyMember Profile successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in InitiativeRegisteredFamilyMember Profile  Creating.";
                }


            }
            else
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        ITEM.InitiativeRegisteredFamilyMemberImage = ImageName;
                    }
                }




                var result = initiativeRegisteredFamilyMemberService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "InitiativeRegisteredFamilyMember Profile successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in InitiativeRegisteredFamilyMember Profile  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbInitiativeRegisteredFamilyMember oldItem = ctx.TbInitiativeRegisteredFamilyMembers.Where(a => a.InitiativeRegisteredFamilyMemberId == id).FirstOrDefault();

            var result = initiativeRegisteredFamilyMemberService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "InitiativeRegisteredFamilyMember Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in InitiativeRegisteredFamilyMember Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbInitiativeRegisteredFamilyMember oldItem = ctx.TbInitiativeRegisteredFamilyMembers.Where(a => a.InitiativeRegisteredFamilyMemberId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
