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

        Task<string> EditUsersImage2(EditUserViewModell editModel);

        Task<string> SSignUpAsync(SignUpModel signUpModel);

        Task<string> LLoginAsync(SignInModel signInModel);


        Task<string> EditUsers(InitiativeRegisteredViewPageModel editModel);
    }
}
