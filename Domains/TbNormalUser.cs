using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbNormalUser
    {
        public Guid NormalUserId { get; set; }
        public string NormalUserName { get; set; }
        public string NormalUserFamilyName { get; set; }
        public string NormalUserBirthDate { get; set; }
        public string NormalUserAge { get; set; }
        public string NormalUserCertificate { get; set; }
        public string NormalUserUniversity { get; set; }
        public string NormalUserJob { get; set; }
        public string NormalUserJobCompany { get; set; }
        public string NormalUserImage { get; set; }
        public string NormalUserPhoneNo { get; set; }
        public string NormalUserMaritalStatus { get; set; }
        public string NormalUserBioigraphy { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
