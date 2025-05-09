using System;
using System.Collections.Generic;

namespace SkladisteAngular.Server.Models
{
    public partial class ItemStore
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }
        public int? StoreId { get; set; }
        public int Quantity { get; set; }

        public virtual Item? Item { get; set; }
        public virtual Store? Store { get; set; }
    }
}
