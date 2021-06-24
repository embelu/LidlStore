using LidlStore.BL.Interfaces;
using LidlStore.Models.Exceptions;
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
    public class ProduitController : ControllerBase
    {
        private readonly IProduitBL _produitBL;
        private readonly ICategorieBL _categorieBL;

        public ProduitController(IProduitBL produitBL, ICategorieBL categorieBL)
        {
            _produitBL = produitBL;
            _categorieBL = categorieBL;
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] ProduitDTO produitDTO)
        {
            try
            {
                var categorie = _categorieBL.GetById(produitDTO.IdCategorie);
                return Ok(_produitBL.Post(produitDTO));
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProduitDTO> GetById(int id)
        {
            try
            {
                return Ok(_produitBL.GetById(id));
            }
            catch (NotFoundException e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<ProduitDTO>> GetAll()
        {
            try
            {
                return Ok(_produitBL.GetAll());
            }
            catch (NotFoundException e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_produitBL.Delete(id));
        }

        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] ProduitDTO produitDTO)
        {
            if (id != produitDTO.Id) return BadRequest();

            return _produitBL.Put(produitDTO);
        }
    }
}
