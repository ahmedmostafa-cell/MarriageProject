using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbInitiativeRegisteredUser
    {
        public Guid InitiativeRegisteredUserId { get; set; }
        public string InitiativeRegisteredUserName { get; set; }
        public string InitiativeRegisteredUserFamilyName { get; set; }
        public string InitiativeRegisteredUserBirthDate { get; set; }
        public string InitiativeRegisteredUserAge { get; set; }
        public string InitiativeRegisteredUserCertificate { get; set; }
        public string InitiativeRegisteredUserUniversity { get; set; }
        public string InitiativeRegisteredUserJob { get; set; }
        public string InitiativeRegisteredUserJobCompany { get; set; }
        public string InitiativeRegisteredUserImage { get; set; }
        public string InitiativeRegisteredUserPhoneNo { get; set; }
        public string InitiativeRegisteredUserMaritalStatus { get; set; }
        public string InitiativeRegisteredUserBioigraphy { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
