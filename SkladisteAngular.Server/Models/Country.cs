using System;
using System.Collections.Generic;

namespace SkladisteAngular.Server.Models
{
    public partial class Country
    {
        public Country()
        {
            Items = new HashSet<Item>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
