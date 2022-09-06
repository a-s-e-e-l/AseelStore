using System;
using System.Collections.Generic;

#nullable disable

namespace AseelStore.Model
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sid { get; set; }
        public DateTime CreateDataUtc { get; set; }
        public DateTime UpdateDataUtc { get; set; }
        public int Archived { get; set; }

        public virtual Subcategory SidNavigation { get; set; }
    }
}
