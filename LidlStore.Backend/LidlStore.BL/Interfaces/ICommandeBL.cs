using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LidlStore.BL.Interfaces
{
    public interface ICommandeBL
    {
        int Post(CommandeDTO commandeDTO);
        List<CommandeDTO> GetAll();
        CommandeDTO GetById(int id);
        int Delete(int id);
        int Put(CommandeDTO commandeDTOUpdated);
    }
}
