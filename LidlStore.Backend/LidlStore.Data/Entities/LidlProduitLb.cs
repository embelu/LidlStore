using System;
using System.Collections.Generic;

#nullable disable

namespace LidlStore.Data.Entities
{
    public partial class LidlProduitLb
    {
        public LidlProduitLb()
        {
            LidlDetailCommandeLbs = new HashSet<LidlDetailCommandeLb>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public string LienImg { get; set; }
        public int IdCategorie { get; set; }

        public virtual LidlCategorieLb IdCategorieNavigation { get; set; }
        public virtual ICollection<LidlDetailCommandeLb> LidlDetailCommandeLbs { get; set; }
    }
}
