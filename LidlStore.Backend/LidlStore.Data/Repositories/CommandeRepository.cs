using LidlStore.Data.Entities;
using LidlStore.Data.Interfaces;
using LidlStore.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LidlStore.Data.Repositories
{
    public class CommandeRepository : ICommandeRepository
    {
        private readonly DB_FormationContext _context;
        public CommandeRepository(DB_FormationContext context)
        {
            _context = context;
        }

        public int Delete(int id)
        {
            var lidlCommandeLbToDelete = _context.LidlCommandeLbs.Where(c => c.Id == id).Include(c => c.LidlDetailCommandeLbs).ThenInclude(d => d.IdProduitNavigation).Single();

            foreach (var item in lidlCommandeLbToDelete.LidlDetailCommandeLbs)
            {
                _context.LidlDetailCommandeLbs.Remove(item);
            }

            _context.LidlCommandeLbs.Remove(lidlCommandeLbToDelete);
            _context.SaveChanges();
            return lidlCommandeLbToDelete.Id;
        }

        public List<CommandeDTO> GetAll()
        {
            List<LidlCommandeLb> lidlCommandeLbs = _context.LidlCommandeLbs.Include(c => c.LidlDetailCommandeLbs).ThenInclude(d => d.IdProduitNavigation).ToList();

            List<CommandeDTO> commandeDTOs = new List<CommandeDTO>();


            foreach (var item in lidlCommandeLbs)
            {
                List<DetailCommandeDTO> detailCommandeDTOs = new List<DetailCommandeDTO>();

                foreach (var itemDetail in item.LidlDetailCommandeLbs)
                {
                    detailCommandeDTOs.Add(new DetailCommandeDTO()
                    {
                        Id = itemDetail.Id,
                        IdCommande = itemDetail.IdCommande,
                        IdProduit = itemDetail.IdProduit,
                        Quantite = itemDetail.Quantite,
                        Produit = new ProduitDTO()
                        {
                            Id = itemDetail.IdProduitNavigation.Id,
                            Description = itemDetail.IdProduitNavigation.Description,
                            Nom = itemDetail.IdProduitNavigation.Nom,
                            IdCategorie = itemDetail.IdProduitNavigation.IdCategorie,
                            LienImg = itemDetail.IdProduitNavigation.LienImg,
                            Prix = itemDetail.IdProduitNavigation.Prix
                        }
                    });
                }

                commandeDTOs.Add(new CommandeDTO() { Id = item.Id, Date = item.Date, Statut = item.Statut, DetailCommandeDTOs = detailCommandeDTOs });
            }

            return commandeDTOs;
        }

        public CommandeDTO GetById(int id)
        {
            LidlCommandeLb lidlCommandeLbs = _context.LidlCommandeLbs.Where(c => c.Id == id).Include(c => c.LidlDetailCommandeLbs).ThenInclude(d => d.IdProduitNavigation).Single();

            List<DetailCommandeDTO> detailCommandeDTOs = new List<DetailCommandeDTO>();

            foreach (var item in lidlCommandeLbs.LidlDetailCommandeLbs)
            {
                detailCommandeDTOs.Add(new DetailCommandeDTO()
                {
                    Id = item.Id,
                    IdCommande = item.IdCommande,
                    IdProduit = item.IdProduit,
                    Quantite = item.Quantite,
                    Produit = new ProduitDTO()
                    {
                        Id = item.IdProduitNavigation.Id,
                        Description = item.IdProduitNavigation.Description,
                        Nom = item.IdProduitNavigation.Nom,
                        IdCategorie = item.IdProduitNavigation.IdCategorie,
                        LienImg = item.IdProduitNavigation.LienImg,
                        Prix = item.IdProduitNavigation.Prix
                    }
                });
            }

            CommandeDTO commandeDTO = new CommandeDTO() { Id = lidlCommandeLbs.Id, Date = lidlCommandeLbs.Date, Statut = lidlCommandeLbs.Statut, DetailCommandeDTOs = detailCommandeDTOs };

            return commandeDTO;
        }

        public int Post(CommandeDTO commandeDTO)
        {
            LidlCommandeLb lidlCommandeLb = new LidlCommandeLb();

            lidlCommandeLb.Date = commandeDTO.Date;
            lidlCommandeLb.Statut = commandeDTO.Statut;
            lidlCommandeLb.LidlDetailCommandeLbs = new List<LidlDetailCommandeLb>();

            foreach (var item in commandeDTO.DetailCommandeDTOs)
            {
                lidlCommandeLb.LidlDetailCommandeLbs.Add(new LidlDetailCommandeLb()
                { IdProduit = item.IdProduit, Quantite = item.Quantite });
            }

            _context.LidlCommandeLbs.Add(lidlCommandeLb);
            _context.SaveChanges();

            return lidlCommandeLb.Id;
        }

        public int Put(CommandeDTO commandeDTOUpdated)
        {
            throw new NotImplementedException();
        }
    }
}
