using System;
using System.Collections.Generic;

#nullable disable

namespace AseelStore.Model
{
    public partial class Category
    {
        public Category()
        {
            Subcategories = new HashSet<Subcategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDataUtc { get; set; }
        public DateTime UpdateDataUtc { get; set; }
        public int Archived { get; set; }

        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
