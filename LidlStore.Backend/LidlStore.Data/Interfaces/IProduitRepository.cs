using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.Data.Interfaces
{
    public interface IProduitRepository
    {
        int Delete(int id);
        List<ProduitDTO> GetAll();
        ProduitDTO GetById(int id);
        int Post(ProduitDTO produitDTO);
        int Put(ProduitDTO produitDTO);
    }
}
