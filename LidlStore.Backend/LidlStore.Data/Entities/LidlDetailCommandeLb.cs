using System;
using System.Collections.Generic;

#nullable disable

namespace LidlStore.Data.Entities
{
    public partial class LidlDetailCommandeLb
    {
        public int Id { get; set; }
        public int IdCommande { get; set; }
        public int IdProduit { get; set; }
        public int Quantite { get; set; }

        public virtual LidlCommandeLb IdCommandeNavigation { get; set; }
        public virtual LidlProduitLb IdProduitNavigation { get; set; }
    }
}
