using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MarriageProject.Models
{
    public class SignUpModel
    {
        public string Password { get; set; }
        public IFormFile PersonalImage { get; set; }
        public string ImageProfile { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime DateCreated { get; set; }
       
        public string RoleId { get; set; }
      
        public string Role { get; set; }

     
        public List<SelectListItem> RoleList { get; set; }


      
        public List<SelectListItem> RoleList2 { get; set; }
      
        public List<string> RoleList3 { get; set; }

        public string PhoneNo { get; set; }

        public IEnumerable<IdentityRole> RoleListMain { get; set; }




        public string FamilyName { get; set; }
        public string BirthDate { get; set; }
        public string Age { get; set; }
        public string Certificate { get; set; }
        public string University { get; set; }
        public string Job { get; set; }
        public string JobCompany { get; set; }


        public string MaritalStatus { get; set; }
        public string Bioigraphy { get; set; }


    }
}
