using System;
using System.Collections.Generic;

#nullable disable

namespace LidlStore.Data.Entities
{
    public partial class LidlCommandeLb
    {
        public LidlCommandeLb()
        {
            LidlDetailCommandeLbs = new HashSet<LidlDetailCommandeLb>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Statut { get; set; }

        public virtual ICollection<LidlDetailCommandeLb> LidlDetailCommandeLbs { get; set; }
    }
}
