using BL;
using MarriageProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using System;
using Domains;
using System.Linq;

namespace MarriageProject.Controllers
{
    public class AccountRepository : IAccountRepository
    {
        SignInManager<ApplicationUser> SignInManager;
        UserManager<ApplicationUser> Usermanager;
        MarriagedDbContext Ctx;
        NormalUserService userService;
        public AccountRepository(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> usermanager,MarriagedDbContext ctx, NormalUserService UserService)
        {
            userService = UserService;
            Usermanager = usermanager;
             Ctx = ctx;
            SignInManager = signInManager;

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



        public async Task<ApplicationUser> SSignUpAsync(SignUpModel signUpModel)
        {

            if (signUpModel.PersonalImage != null)
            {
                string ImageName = Guid.NewGuid().ToString() + ".jpg";
                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                using (var stream = System.IO.File.Create(filePaths))
                {
                    await signUpModel.PersonalImage.CopyToAsync(stream);
                }
                signUpModel.ImageProfile = ImageName;
            }
            else
            {
                signUpModel.ImageProfile = "6bfaa416-900f-478b-a44d-984e099bd723.jpg";

            }

            var user = new ApplicationUser()
            {
                Email = signUpModel.Email,
                UserName = signUpModel.UserName,
                EmailConfirmed = true



            };
            



            var r =  await Usermanager.CreateAsync(user, signUpModel.Password);
            var res2 = Usermanager.Users.Where(a => a.Id == user.Id).FirstOrDefault();
            return res2;
        }



        public async Task<ApplicationUser> LLoginAsync(SignInModel signInModel)
        {
            var result = await SignInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, true, true);

            if (!result.Succeeded)
            {
                return null;
            }
            else
            {
               

                var res2 = Usermanager.Users.Where(a => a.UserName == signInModel.Email).FirstOrDefault();

                return res2;
            }

           
        }
    }
}
