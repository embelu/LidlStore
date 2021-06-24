using AutoMapper;
using LidlStore.Data.Entities;
using LidlStore.Data.Interfaces;
using LidlStore.Models.Exceptions;
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
        private MapperConfiguration configToEntities;
        private MapperConfiguration configToDTO;
        private MapperConfiguration configToDTOBis;

        public CategorieRepository(DB_FormationContext context)
        {
            _context = context;

            configToEntities = new MapperConfiguration(cfg => cfg.CreateMap<CategorieDTO, LidlCategorieLb>());
            configToDTO = new MapperConfiguration(cfg => cfg.CreateMap<LidlCategorieLb, CategorieDTO>());
            // Exemple de mappage de propriétés explicites (ici peut de sens car les propriétés portent le même nom
            // mais c'est simplement pour connaitre la synthaxe.
            configToDTOBis = new MapperConfiguration(cfg => cfg.CreateMap<LidlCategorieLb, CategorieDTO>()
            .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description)));
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

            if (lidlCategorieLbs.Count == 0)
            {
                throw new NotFoundException("Pas de catégories présentes en DB");
            }

            List<CategorieDTO> categorieDTOs = new List<CategorieDTO>();
            var mapper = new Mapper(configToDTOBis);
            categorieDTOs = lidlCategorieLbs.Select(lidlCat => mapper.Map<CategorieDTO>(lidlCat)).ToList();

            // REMPLACE PAR AUTOMAPPER
            //foreach (var item in lidlCategorieLbs)
            //{
            //    categorieDTOs.Add(new CategorieDTO() { Id = item.Id, Nom = item.Nom, Description = item.Description, LienImg = item.LienImg });

            //}

            return categorieDTOs;
        }

        public CategorieDTO GetById(int id)
        {
            LidlCategorieLb lidlCategorieLb = _context.LidlCategorieLbs.Find(id);

            if (lidlCategorieLb == null)
            {
                throw new NotFoundException($"Categorie inexistante :  {id} !");
            }

            var mapper = new Mapper(configToDTO);
            return mapper.Map<CategorieDTO>(lidlCategorieLb);

            //return new CategorieDTO()
            //{
            //    Id = lidlCategorieLb.Id,
            //    Nom = lidlCategorieLb.Nom,
            //    Description = lidlCategorieLb.Description,
            //    LienImg = lidlCategorieLb.LienImg
            //};
        }

        public int Post(CategorieDTO categorieDTO)
        {
            var mapper = new Mapper(configToEntities);
            LidlCategorieLb lidlCategorieLb = mapper.Map<LidlCategorieLb>(categorieDTO);

            // REMPLACE PAR AUTOMAPPER
            //LidlCategorieLb lidlCategorieLb = new LidlCategorieLb();
            //lidlCategorieLb.Nom = categorieDTO.Nom;
            //lidlCategorieLb.Description = categorieDTO.Description;
            //lidlCategorieLb.LienImg = categorieDTO.LienImg;

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
