using Domains;
using System.Collections.Generic;

namespace MarriageProject.Models
{
    public class HomePageModel
    {
        public IEnumerable<TbInitiativeRegisteredFamilyMember> lstInitiativeRegisteredFamilyMemberS { get; set; }
        public IEnumerable<TbInitiativeRegisteredUser> lstInitiativeRegisteredUser { get; set; }
        public IEnumerable<TbInitiativeTerm> lstInitiativeTerm { get; set; }

        public IEnumerable<TbNormalUser> lstNormalUserS { get; set; }

        public IEnumerable<TbSlider> lstSliders { get; set; }


        public IEnumerable<VwRegisteredUser> lVwRegisteredUser { get; set; }


        public IEnumerable<VwRegisteredUser2> lVwRegisteredUser2 { get; set; }

        public IEnumerable<TbComplainsAndSuggestion> lstComplainsAndSuggestions { get; set; }
    }
}
