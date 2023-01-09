using BL;
using Domains;
using MarriageProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MarriageProject.Controllers
{
    public interface IAccountRepository
    {
        Task<TbNormalUser>  EditUsersImage(EditUserViewModell editModel);

        Task<ApplicationUser> SSignUpAsync(SignUpModel signUpModel);

        Task<ApplicationUser> LLoginAsync(SignInModel signInModel);
    }
}
