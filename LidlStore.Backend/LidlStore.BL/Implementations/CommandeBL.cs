using LidlStore.BL.Interfaces;
using LidlStore.Data.Interfaces;
using LidlStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LidlStore.BL.Implementations
{
    public class CommandeBL : ICommandeBL
    {
        private readonly ICommandeRepository _commandeRepository;
        private readonly IDetailCommandeRepository _detailCommandeRepository;

        public CommandeBL(ICommandeRepository commandeRepository, IDetailCommandeRepository detailCommandeRepository)
        {
            _commandeRepository = commandeRepository;
            _detailCommandeRepository = detailCommandeRepository;
        }

        public int Delete(int id)
        {
            return _commandeRepository.Delete(id);
        }

        public List<CommandeDTO> GetAll()
        {
            return _commandeRepository.GetAll();  
        }

        public CommandeDTO GetById(int id)
        {
             return _commandeRepository.GetById(id);
        }

        public int Post(CommandeDTO commandeDTO)
        {
            return _commandeRepository.Post(commandeDTO);
        }

        public int Put(CommandeDTO commandeDTOUpdated)
        {
            var commandeDtoDb = _commandeRepository.GetById(commandeDTOUpdated.Id);

            //DETAILS A AJOUTER
            List<DetailCommandeDTO> detailCommandeDtoToCreate = commandeDTOUpdated.DetailCommandeDTOs.Where(c => c.Id == 0).ToList();

            foreach (var item in detailCommandeDtoToCreate)
            {
                _detailCommandeRepository.Post(item);
            }

            // DETAILS A SUPPRIMER
            List<DetailCommandeDTO> detailCommandeDtoToDelete = commandeDtoDb.DetailCommandeDTOs.Where(dc => !commandeDTOUpdated.DetailCommandeDTOs.Any(d => dc.Id == d.Id)).ToList();

            foreach (var item in detailCommandeDtoToDelete)
            {
                _detailCommandeRepository.Delete(item.Id);
            }


            // DETAILS A MODIFIER
            List<DetailCommandeDTO> detailCommandeDtoToUpdate = commandeDTOUpdated.DetailCommandeDTOs.Where(dc => commandeDtoDb.DetailCommandeDTOs.Any(d => dc.Id == d.Id)).ToList();

            foreach (var item in detailCommandeDtoToUpdate)
            {
                _detailCommandeRepository.Put(item);
            }

            return commandeDTOUpdated.Id;
        }
    }
}
