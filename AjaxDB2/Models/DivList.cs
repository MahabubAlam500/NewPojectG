using System;
using System.Collections.Generic;

#nullable disable

namespace AjaxDB2.Models
{
    public partial class DivList
    {
        public DivList()
        {
            Districts = new HashSet<District>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}
