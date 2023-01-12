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



        [HttpPost]
        public async Task<string> EditUsersImage2(EditUserViewModell model)
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
            var user = await Usermanager.FindByIdAsync(model.Id);
            TbNormalUser oTbNormalUser = new TbNormalUser();
            user.Name = model.NormalUserName;
            user.FamilyName = model.NormalUserFamilyName;
            user.Age = model.NormalUserAge;
            user.PhoneNumber = model.NormalUserPhoneNo;
            user.Certificate = model.NormalUserCertificate;
            user.MaritalStatus = model.NormalUserMaritalStatus;
            user.ImageProfile = model.NormalUserImage;
            user.Status = "Normal User";
            var result = await Usermanager.UpdateAsync(user);






            return result.ToString();



        }



        public async Task<string> SSignUpAsync(SignUpModel signUpModel)
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
                //Email = "ahmedmostafa706@gmail.com",
                UserName = signUpModel.UserName,
               



            };
            



            var r =  await Usermanager.CreateAsync(user, signUpModel.Password);
           
            return r.ToString();
        }



        public async Task<string> LLoginAsync(SignInModel signInModel)
        {
            var result = await SignInManager.PasswordSignInAsync(signInModel.UserName, signInModel.Password, true, true);
         
               
                return result.ToString();
           

               
           

           
        }




        [HttpPost]
        public async Task<string> EditUsers(InitiativeRegisteredViewPageModel model)
        {

          
            var user = await Usermanager.FindByIdAsync(model.Id);

            user.Name = model.InitiativeRegisteredUserName;
            user.FamilyName = model.InitiativeRegisteredUserFamilyName;
            user.Age = model.InitiativeRegisteredUserAge;
            user.PhoneNumber = model.InitiativeRegisteredUserPhoneNo;

            user.Status = "Initiative Registered User";






            var result = await Usermanager.UpdateAsync(user);




          

            return result.ToString();



        }
    }
}
