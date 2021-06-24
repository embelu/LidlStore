using LidlStore.Data.Entities;
using LidlStore.Data.Interfaces;
using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.Data.Repositories
{
    public class DetailCommandeRepository : IDetailCommandeRepository
    {
        private readonly DB_FormationContext _context;
        public DetailCommandeRepository(DB_FormationContext context)
        {
            _context = context;
        }


        public int Delete(int id)
        {
            LidlDetailCommandeLb lidlDetailCommandeLb = _context.LidlDetailCommandeLbs.Find(id);

            _context.LidlDetailCommandeLbs.Remove(lidlDetailCommandeLb);
            _context.SaveChanges();
            return lidlDetailCommandeLb.Id;
        }


        public int Post(DetailCommandeDTO detailCommandeDTO)
        {
            LidlDetailCommandeLb lidlDetailCommandeLb = new LidlDetailCommandeLb();
            lidlDetailCommandeLb.IdProduit = detailCommandeDTO.IdProduit;
            lidlDetailCommandeLb.Quantite = detailCommandeDTO.Quantite;
            lidlDetailCommandeLb.IdCommande = detailCommandeDTO.IdCommande;

            _context.LidlCommandeLbs.Find(detailCommandeDTO.IdCommande);
            _context.LidlDetailCommandeLbs.Add(lidlDetailCommandeLb);
            _context.SaveChanges();
            return detailCommandeDTO.Id;
        }


        public int Put(DetailCommandeDTO detailCommandeDTO)
        {
            LidlDetailCommandeLb lidlDetailCommandeLb = _context.LidlDetailCommandeLbs.Find(detailCommandeDTO.Id);
            lidlDetailCommandeLb.Quantite = detailCommandeDTO.Quantite;

            _context.LidlDetailCommandeLbs.Update(lidlDetailCommandeLb);
            _context.SaveChanges();

            return detailCommandeDTO.Id;
        }
    }
}
