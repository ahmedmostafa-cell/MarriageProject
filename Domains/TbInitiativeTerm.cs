using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbInitiativeTerm
    {
        public Guid InitiativeTermId { get; set; }
        public string InitiativeTermText { get; set; }
        public string InitiativeTermImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
        public int? OrderNo { get; set; }
    }
}
