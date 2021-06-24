using LidlStore.Data.Entities;
using LidlStore.Data.Interfaces;
using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LidlStore.Data.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly DB_FormationContext _context;

        public CategorieRepository(DB_FormationContext context)
        {
            _context = context;
        }

        public int Delete(int id)
        {
            LidlCategorieLb lidlCategorieLb = _context.LidlCategorieLbs.Find(id);

            _context.LidlCategorieLbs.Remove(lidlCategorieLb);
            _context.SaveChanges();
            return lidlCategorieLb.Id;
        }

        public List<CategorieDTO> GetAll()
        {
            List<LidlCategorieLb> lidlCategorieLbs =  _context.LidlCategorieLbs.ToList();

            List<CategorieDTO> categorieDTOs = new List<CategorieDTO>();
            foreach (var item in lidlCategorieLbs)
            {
                categorieDTOs.Add(new CategorieDTO() { Id = item.Id, Nom = item.Nom, Description = item.Description, LienImg = item.LienImg });

            }

            return categorieDTOs;
        }

        public CategorieDTO GetById(int id)
        {
            LidlCategorieLb lidlCategorieLb = _context.LidlCategorieLbs.Find(id);

            return new CategorieDTO()
            {
                Id = lidlCategorieLb.Id,
                Nom = lidlCategorieLb.Nom,
                Description = lidlCategorieLb.Description,
                LienImg = lidlCategorieLb.LienImg
            };
        }

        public int Post(CategorieDTO categorieDTO)
        {
            LidlCategorieLb lidlCategorieLb = new LidlCategorieLb();
            lidlCategorieLb.Nom = categorieDTO.Nom;
            lidlCategorieLb.Description = categorieDTO.Description;
            lidlCategorieLb.LienImg = categorieDTO.LienImg;

            _context.LidlCategorieLbs.Add(lidlCategorieLb);
            _context.SaveChanges();
            return lidlCategorieLb.Id;
        }


        public int Put(CategorieDTO categorieDTO)
        {
            var lidlCategorieLbtoUpdate = _context.LidlCategorieLbs.Find(categorieDTO.Id);

            lidlCategorieLbtoUpdate.Nom = categorieDTO.Nom;
            lidlCategorieLbtoUpdate.Description = categorieDTO.Description;
            lidlCategorieLbtoUpdate.LienImg = categorieDTO.LienImg;

            _context.LidlCategorieLbs.Update(lidlCategorieLbtoUpdate);
            _context.SaveChanges();

            return lidlCategorieLbtoUpdate.Id;
        }
    }
}
