using System;
using System.Collections.Generic;

#nullable disable

namespace AseelStore.Model
{
    public partial class Subcategory
    {
        public Subcategory()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Cid { get; set; }
        public DateTime CreateDataUtc { get; set; }
        public DateTime UpdateDataUtc { get; set; }
        public int Archived { get; set; }

        public virtual Category CidNavigation { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
