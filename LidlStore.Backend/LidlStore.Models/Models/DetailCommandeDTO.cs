using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.Models.Models
{
    public class DetailCommandeDTO
    {
        public int Id { get; set; }
        public int IdCommande { get; set; }
        public int IdProduit { get; set; }
        public int Quantite { get; set; }
        public ProduitDTO Produit { get; set; }
    }
}
