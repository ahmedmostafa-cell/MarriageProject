using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbInitiativeRegisteredFamilyMember
    {
        public Guid InitiativeRegisteredFamilyMemberId { get; set; }
        public string InitiativeRegisteredFamilyMemberName { get; set; }
        public string InitiativeRegisteredFamilyMemberFamilyName { get; set; }
        public string InitiativeRegisteredFamilyMemberBirthDate { get; set; }
        public string InitiativeRegisteredFamilyMemberAge { get; set; }
        public string InitiativeRegisteredFamilyMemberCertificate { get; set; }
        public string InitiativeRegisteredFamilyMemberUniversity { get; set; }
        public string InitiativeRegisteredFamilyMemberJob { get; set; }
        public string InitiativeRegisteredFamilyMemberJobCompany { get; set; }
        public string InitiativeRegisteredFamilyMemberImage { get; set; }
        public string InitiativeRegisteredFamilyMemberPhoneNo { get; set; }
        public string InitiativeRegisteredFamilyMemberMaritalStatus { get; set; }
        public string InitiativeRegisteredFamilyMemberBiography { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }


        public Guid InitiativeRegisteredUserId { get; set; }

        
    }
}
