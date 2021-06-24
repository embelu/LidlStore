using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.Data.Interfaces
{
    public interface ICategorieRepository
    {
        int Post(CategorieDTO categorieDTO);
        List<CategorieDTO> GetAll();
        CategorieDTO GetById(int id);
        int Put(CategorieDTO categorieDTO);
        int Delete(int id);
    }
}
