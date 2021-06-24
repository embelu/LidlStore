using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.Models.Models
{
    public class CommandeDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Statut { get; set; }
        public List<DetailCommandeDTO> DetailCommandeDTOs { get; set; }
    }
}
