using System;
using System.Collections.Generic;

namespace SkladisteAngular.Server.Models
{
    public partial class Deliverer
    {
        public Deliverer()
        {
            Items = new HashSet<Item>();
        }

        public int DelivererId { get; set; }
        public string Name { get; set; } = null!;
        public string? ContactPhone { get; set; }
        public string? ContactMail { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
