using System;
using System.Collections.Generic;

namespace SkladisteAngular.Server.Models
{
    public partial class Store
    {
        public Store()
        {
            ItemStores = new HashSet<ItemStore>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual ICollection<ItemStore> ItemStores { get; set; }
    }
}
