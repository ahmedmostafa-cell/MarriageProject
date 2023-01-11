using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BL
{
    public class ApplicationUser:IdentityUser
    {
        public string? Status { get; set; }
        public string? ImageProfile { get; set; }

        public string? Name { get; set; }
        public DateTime DateCreated { get; set; }
        [NotMapped]
        public string? RoleId { get; set; }
        [NotMapped]
        public string? Role { get; set; }

        [NotMapped]
        public List<SelectListItem>? RoleList { get; set; }


        [NotMapped]
        public List<SelectListItem>? RoleList2 { get; set; }
        [NotMapped]
        public List<string>? RoleList3 { get; set; }


        [NotMapped]
        public IEnumerable<IdentityRole>? RoleListMain { get; set; }



       
        public string? FamilyName { get; set; }
        public string? BirthDate { get; set; }
        public string? Age { get; set; }
        public string? Certificate { get; set; }
        public string? University { get; set; }
        public string? Job { get; set; }
        public string? JobCompany { get; set; }
      
       
        public string? MaritalStatus { get; set; }
        public string? Bioigraphy { get; set; }


    }
}
