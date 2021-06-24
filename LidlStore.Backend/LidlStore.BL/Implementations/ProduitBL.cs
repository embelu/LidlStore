using LidlStore.BL.Interfaces;
using LidlStore.Data.Interfaces;
using LidlStore.Models.Exceptions;
using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.BL.Implementations
{
    public class ProduitBL : IProduitBL
    {
        private readonly IProduitRepository _produitRepository;

        public ProduitBL(IProduitRepository produitRepository)
        {
            _produitRepository = produitRepository;
        }

        public int Delete(int id)
        {
            return _produitRepository.Delete(id);
        }

        public List<ProduitDTO> GetAll()
        {
            var produitDTOs = _produitRepository.GetAll();

            return produitDTOs;
        }

        public ProduitDTO GetById(int id)
        {
            ProduitDTO produitDTO = _produitRepository.GetById(id);

            return produitDTO;
        }

        public int Post(ProduitDTO produitDTO)
        {
            return _produitRepository.Post(produitDTO);
        }

        public int Put(ProduitDTO produitDTO)
        {
            return _produitRepository.Put(produitDTO);
        }
    }
}
