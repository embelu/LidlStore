using LidlStore.BL.Interfaces;
using LidlStore.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LidlStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly ICommandeBL _commandeBL;

        public CommandeController(ICommandeBL commandeBL)
        {
            _commandeBL = commandeBL;
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] CommandeDTO commandeDTO)
        {
            return Ok(_commandeBL.Post(commandeDTO));
        }


        [HttpGet]
        public ActionResult<List<CommandeDTO>> GetAll()
        {
            return Ok(_commandeBL.GetAll());
        }


        // GET api/<CommandeController>/5
        [HttpGet("{id}")]
        public ActionResult<CommandeDTO> GetById(int id)
        {
            return Ok(_commandeBL.GetById(id));
        }


        // DELETE api/<CommandeController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_commandeBL.Delete(id));
        }


        // PUT api/<CommandeController>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] CommandeDTO commandeDTOUpdated)
        {
            if (id != commandeDTOUpdated.Id) return BadRequest();

            return _commandeBL.Put(commandeDTOUpdated);
        }
    }
}
