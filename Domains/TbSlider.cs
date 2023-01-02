using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSlider
    {
        public Guid SliderId { get; set; }
        public string SliderTitle { get; set; }
        public string SliderText { get; set; }
        public string SliderImage { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Notes { get; set; }
        public int? CurrentState { get; set; }
        public int? OrderNo { get; set; }
    }
}
