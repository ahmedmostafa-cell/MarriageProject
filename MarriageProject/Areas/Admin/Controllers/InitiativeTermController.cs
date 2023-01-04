using BL;
using Domains;
using MarriageProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MarriageProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InitiativeTermController : Controller
    {
        InitiativeRegisteredFamilyMemberService initiativeRegisteredFamilyMemberService;
        InitiativeRegisteredUserService initiativeRegisteredUserService;
        InitiativeTermService initiativeTermService;
        MarriagedDbContext ctx;

        public InitiativeTermController(InitiativeTermService InitiativeTermService ,InitiativeRegisteredUserService InitiativeRegisteredUserService, InitiativeRegisteredFamilyMemberService InitiativeRegisteredFamilyMemberService, MarriagedDbContext context)
        {

            ctx = context;
            initiativeRegisteredFamilyMemberService = InitiativeRegisteredFamilyMemberService;
            initiativeRegisteredUserService = InitiativeRegisteredUserService;
            initiativeTermService = InitiativeTermService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            model.lstInitiativeRegisteredUser = initiativeRegisteredUserService.getAll();
            model.lstInitiativeTerm = initiativeTermService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbInitiativeTerm ITEM, List<IFormFile> files)
        {


            if (ITEM.InitiativeTermId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.InitiativeTermImage = ImageName;
                    }
                }


                var result = initiativeTermService.Add(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "InitiativeTerm Profile successfully Created.";
                }
                else
                {
                    TempData[SD.Error] = "Error in InitiativeTerm Profile  Creating.";
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
                        ITEM.InitiativeTermImage = ImageName;
                    }
                }




                var result = initiativeTermService.Edit(ITEM);
                if (result == true)
                {
                    TempData[SD.Success] = "InitiativeTerm Profile successfully Updated.";
                }
                else
                {
                    TempData[SD.Error] = "Error in InitiativeTerm Profile  Updating.";
                }

            }


            HomePageModel model = new HomePageModel();
            model.lstInitiativeTerm = initiativeTermService.getAll();
            model.lstInitiativeRegisteredUser = initiativeRegisteredUserService.getAll();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbInitiativeTerm oldItem = ctx.TbInitiativeTerms.Where(a => a.InitiativeTermId == id).FirstOrDefault();

            var result = initiativeTermService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "InitiativeTerm Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in InitiativeTerm Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstInitiativeTerm = initiativeTermService.getAll();
            model.lstInitiativeRegisteredUser = initiativeRegisteredUserService.getAll();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbInitiativeTerm oldItem = ctx.TbInitiativeTerms.Where(a => a.InitiativeTermId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
