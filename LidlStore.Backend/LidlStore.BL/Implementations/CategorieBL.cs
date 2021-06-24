using LidlStore.BL.Interfaces;
using LidlStore.Data.Interfaces;
using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.BL.Implementations
{
    public class CategorieBL : ICategorieBL
    {
        private readonly ICategorieRepository _categorieRepository;

        public CategorieBL(ICategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }

        public int Delete(int id)
        {
            return _categorieRepository.Delete(id);
        }

        public List<CategorieDTO> GetAll()
        {
            return _categorieRepository.GetAll();
        }

        public CategorieDTO GetById(int id)
        {
            CategorieDTO categorieDTO = _categorieRepository.GetById(id);

            return categorieDTO;
        }

        public int Post(CategorieDTO categorieDTO)
        {
            return _categorieRepository.Post(categorieDTO);
        }

        public int Put(CategorieDTO categorieDTO)
        {
            return _categorieRepository.Put(categorieDTO);
        }
    }
}
