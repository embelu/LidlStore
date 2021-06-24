using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.Data.Interfaces
{
    public interface IDetailCommandeRepository
    {
        int Post(DetailCommandeDTO detailCommandeDTO);
        int Delete(int id);
        int Put(DetailCommandeDTO detailCommandeDTO);
    }
}
