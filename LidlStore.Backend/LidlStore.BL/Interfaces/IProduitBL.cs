using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.BL.Interfaces
{
    public interface IProduitBL
    {
        int Post(ProduitDTO produitDTO);
        List<ProduitDTO> GetAll();
        ProduitDTO GetById(int id);
        int Put(ProduitDTO produitDTO);
        int Delete(int id);
    }
}
