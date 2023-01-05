using BL;
using MarriageProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using System;
using Domains;

namespace MarriageProject.Controllers
{
    public class AccountRepository : IAccountRepository
    {
       
        MarriagedDbContext Ctx;
       NormalUserService userService;
        public AccountRepository(MarriagedDbContext ctx, NormalUserService UserService)
        {
            userService = UserService;
           
            Ctx = ctx;
         

        }

        [HttpPost]
        public async Task<TbNormalUser>  EditUsersImage(EditUserViewModell model)
        {
            if (model.PersonalImage != null)
            {
                string ImageName = Guid.NewGuid().ToString() + ".jpg";
                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                using (var stream = System.IO.File.Create(filePaths))
                {
                     await model.PersonalImage.CopyToAsync(stream);
                }
                model.NormalUserImage = ImageName;
            }
           TbNormalUser oTbNormalUser = new TbNormalUser();
            oTbNormalUser.NormalUserName = model.NormalUserName;
            oTbNormalUser.NormalUserFamilyName = model.NormalUserFamilyName;
            oTbNormalUser.NormalUserAge = model.NormalUserAge;
            oTbNormalUser.NormalUserPhoneNo = model.NormalUserPhoneNo;
            oTbNormalUser.NormalUserCertificate = model.NormalUserCertificate;
            oTbNormalUser.NormalUserMaritalStatus = model.NormalUserMaritalStatus;
            oTbNormalUser.NormalUserImage = model.NormalUserImage;
            
            var result = await  userService.AddAsync(oTbNormalUser);








            return oTbNormalUser;



        }
    }
}
