﻿using Microsoft.AspNetCore.Http;

namespace MarriageProject.Models
{
    public class EditUserViewModell
    {
        public string NormalUserName { get; set; }
        public string NormalUserFamilyName { get; set; }
      
        public string NormalUserAge { get; set; }
        public string NormalUserCertificate { get; set; }
      
        public string NormalUserImage { get; set; }
        public string NormalUserPhoneNo { get; set; }
        public string NormalUserMaritalStatus { get; set; }

        public IFormFile PersonalImage { get; set; }

    }
}
