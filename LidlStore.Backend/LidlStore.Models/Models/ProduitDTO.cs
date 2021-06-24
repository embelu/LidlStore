using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.Models.Models
{
    public class ProduitDTO
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public string LienImg { get; set; }
        public int IdCategorie { get; set; }
    }
}
