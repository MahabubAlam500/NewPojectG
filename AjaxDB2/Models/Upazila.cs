using System;
using System.Collections.Generic;

#nullable disable

namespace AjaxDB2.Models
{
    public partial class Upazila
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }

        public virtual District District { get; set; }
    }
}
