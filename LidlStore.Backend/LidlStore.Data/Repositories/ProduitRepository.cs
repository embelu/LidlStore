using LidlStore.Data.Entities;
using LidlStore.Data.Helpers;
using LidlStore.Data.Interfaces;
using LidlStore.Models.Exceptions;
using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LidlStore.Data.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        private readonly DB_FormationContext _context;

        public ProduitRepository(DB_FormationContext context)
        {
            _context = context;
        }

        public int Delete(int id)
        {
            LidlProduitLb lidlProduitLb = _context.LidlProduitLbs.Find(id);
            _context.LidlProduitLbs.Remove(lidlProduitLb);

            _context.SaveChanges();
            return lidlProduitLb.Id;
        }

        public List<ProduitDTO> GetAll()
        {
            List<LidlProduitLb> lidlProduitLbs = _context.LidlProduitLbs.ToList();

            if (lidlProduitLbs.Count == 0)
            {
                throw new NotFoundException("Pas de produits présents en DB");
            }

            List<ProduitDTO> produitDTOs = new List<ProduitDTO>();
            foreach (var item in lidlProduitLbs)
            {
                produitDTOs.Add(new ProduitDTO() { Id = item.Id, Nom = item.Nom, Description = item.Description, LienImg = item.LienImg, IdCategorie = item.IdCategorie, Prix = item.Prix });

            }

            return produitDTOs;
        }

        public ProduitDTO GetById(int id)
        {
            LidlProduitLb lidlProduitLb = _context.LidlProduitLbs.Find(id);

            if (lidlProduitLb == null)
            {
                throw new NotFoundException($"Produit inexistant :  {id} !");
            }

            return lidlProduitLb.ToDTO();

            // REMPLACE PAR METHODE EXTENSION
            //return new ProduitDTO()
            //{
            //    Id = lidlProduitLb.Id,
            //    Nom = lidlProduitLb.Nom,
            //    Description = lidlProduitLb.Description,
            //    LienImg = lidlProduitLb.LienImg,
            //    IdCategorie = lidlProduitLb.IdCategorie,
            //    Prix = lidlProduitLb.Prix
            //};
        }

        public int Post(ProduitDTO produitDTO)
        {
            LidlProduitLb lidlProduitLb = new LidlProduitLb();

            lidlProduitLb = produitDTO.FromDTO();
        
            // REMPLACE PAR METHODE EXTENSION
            //lidlProduitLb.Nom = produitDTO.Nom;
            //lidlProduitLb.Description = produitDTO.Description;
            //lidlProduitLb.LienImg = produitDTO.LienImg;
            //lidlProduitLb.IdCategorie = produitDTO.IdCategorie;
            //lidlProduitLb.Prix = produitDTO.Prix;

            _context.LidlProduitLbs.Add(lidlProduitLb);
            _context.SaveChanges();
            return lidlProduitLb.Id;
        }


        public int Put(ProduitDTO produitDTO)
        {
            var lidlProduitLbtoUpdate = _context.LidlProduitLbs.Find(produitDTO.Id);

            lidlProduitLbtoUpdate.Nom = produitDTO.Nom;
            lidlProduitLbtoUpdate.Description = produitDTO.Description;
            lidlProduitLbtoUpdate.LienImg = produitDTO.LienImg;
            lidlProduitLbtoUpdate.IdCategorie = produitDTO.IdCategorie;
            lidlProduitLbtoUpdate.Prix = produitDTO.Prix;

            _context.LidlProduitLbs.Update(lidlProduitLbtoUpdate);
            _context.SaveChanges();

            return lidlProduitLbtoUpdate.Id;
        }
    }
}
