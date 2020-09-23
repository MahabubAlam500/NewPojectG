using System;
using System.Collections.Generic;

#nullable disable

namespace AjaxDB2.Models
{
    public partial class District
    {
        public District()
        {
            Upazilas = new HashSet<Upazila>();
        }

        public int Id { get; set; }
        public int DivListId { get; set; }
        public string Name { get; set; }

        public virtual DivList DivList { get; set; }
        public virtual ICollection<Upazila> Upazilas { get; set; }
    }
}
