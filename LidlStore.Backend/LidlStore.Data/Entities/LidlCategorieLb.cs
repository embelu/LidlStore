using System;
using System.Collections.Generic;

#nullable disable

namespace LidlStore.Data.Entities
{
    public partial class LidlCategorieLb
    {
        public LidlCategorieLb()
        {
            LidlProduitLbs = new HashSet<LidlProduitLb>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string LienImg { get; set; }

        public virtual ICollection<LidlProduitLb> LidlProduitLbs { get; set; }
    }
}
