using System;
using System.Collections.Generic;

namespace SkladisteAngular.Server.Models
{
    public partial class Item
    {
        public Item()
        {
            ItemStores = new HashSet<ItemStore>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int? DelivererId { get; set; }
        public int? CountryId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Country? Country { get; set; }
        public virtual Deliverer? Deliverer { get; set; }
        public virtual ICollection<ItemStore> ItemStores { get; set; }
    }
}
