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
    public class SliderController : Controller
    {
        InitiativeRegisteredFamilyMemberService initiativeRegisteredFamilyMemberService;
        InitiativeRegisteredUserService initiativeRegisteredUserService;
        SliderService sliderService;
        MarriagedDbContext ctx;

        public SliderController(SliderService SliderService ,InitiativeRegisteredUserService InitiativeRegisteredUserService, InitiativeRegisteredFamilyMemberService InitiativeRegisteredFamilyMemberService, MarriagedDbContext context)
        {

            ctx = context;
            initiativeRegisteredFamilyMemberService = InitiativeRegisteredFamilyMemberService;
            initiativeRegisteredUserService = InitiativeRegisteredUserService;
            sliderService = SliderService;

        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();
            model.lstSliders = sliderService.getAll();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            model.lstInitiativeRegisteredUser = initiativeRegisteredUserService.getAll();
            return View(model);


        }


        public async Task<IActionResult> Save(TbSlider ITEM, List<IFormFile> files)
        {


            if (ITEM.SliderId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
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
                        ITEM.SliderImage = ImageName;
                    }
                }


                var result = sliderService.Add(ITEM);
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
                        ITEM.SliderImage = ImageName;
                    }
                }




                var result = sliderService.Edit(ITEM);
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
            model.lstSliders = sliderService.getAll();
            model.lstInitiativeRegisteredUser = initiativeRegisteredUserService.getAll();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            return View("Index", model);
        }





        public IActionResult Delete(Guid id)
        {

            TbSlider oldItem = ctx.TbSliders.Where(a => a.SliderId == id).FirstOrDefault();

            var result = sliderService.Delete(oldItem);
            if (result == true)
            {
                TempData[SD.Success] = "InitiativeRegisteredUser Profile successfully Removed.";
            }
            else
            {
                TempData[SD.Error] = "Error in InitiativeRegisteredUser Profile  Removing.";
            }

            HomePageModel model = new HomePageModel();
            model.lstSliders = sliderService.getAll();
            model.lstInitiativeRegisteredUser = initiativeRegisteredUserService.getAll();
            model.lstInitiativeRegisteredFamilyMemberS = initiativeRegisteredFamilyMemberService.getAll();
            return View("Index", model);



        }




        public IActionResult Form(Guid? id)
        {
            TbSlider oldItem = ctx.TbSliders.Where(a => a.SliderId == id).FirstOrDefault();


            return View(oldItem);
        }
    }
}
