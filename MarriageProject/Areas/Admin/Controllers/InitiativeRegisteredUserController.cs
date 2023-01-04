using BL;
using Domains;
using MarriageProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace MarriageProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InitiativeRegisteredUserController : Controller
    {
        InitiativeRegisteredFamilyMemberService initiativeRegisteredFamilyMemberService;
        InitiativeRegisteredUserService initiativeRegisteredUserService;
        MarriagedDbContext ctx;

        public InitiativeRegisteredUserController(InitiativeRegisteredUserService InitiativeRegisteredUserService,InitiativeRegisteredFamilyMemberService InitiativeRegisteredFamilyMemberService, MarriagedDbContext context)
        {

            ctx = context;
            initiativeRegisteredFamilyMemberService = InitiativeRegisteredFamilyMemberService;
            initiativeRegisteredUserService = InitiativeRegisteredUserService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            model.lstInitiativeRegisteredUser = initiativeRegisteredUserService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbInitiativeRegisteredUser ITEM, List<IFormFile> files)
        {


            if (ITEM.InitiativeRegisteredUserId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.InitiativeRegisteredUserImage = ImageName;
                    }
                }


                var result = initiativeRegisteredUserService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "InitiativeRegisteredUser Profile successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in InitiativeRegisteredUser Profile  Creating.";
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
                        ITEM.InitiativeRegisteredUserImage = ImageName;
                    }
                }




                var result = initiativeRegisteredUserService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "InitiativeRegisteredUser Profile successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in InitiativeRegisteredUser Profile  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lstInitiativeRegisteredUser = initiativeRegisteredUserService.getAll();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbInitiativeRegisteredUser oldItem = ctx.TbInitiativeRegisteredUsers.Where(a => a.InitiativeRegisteredUserId == id).FirstOrDefault();

            var result = initiativeRegisteredUserService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "InitiativeRegisteredUser Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in InitiativeRegisteredUser Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstInitiativeRegisteredUser = initiativeRegisteredUserService.getAll();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbInitiativeRegisteredUser oldItem = ctx.TbInitiativeRegisteredUsers.Where(a => a.InitiativeRegisteredUserId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
