using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class TbComplainsAndSuggestion
    {
        public Guid ComplaintsAndSuggestionsId { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? ComplaintsAndSuggestionsText { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Notes { get; set; }
        public int? CurrentState { get; set; }
    }
}
