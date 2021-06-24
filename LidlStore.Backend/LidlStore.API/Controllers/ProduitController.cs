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
    public class ProduitController : ControllerBase
    {
        private readonly IProduitBL _produitBL;

        public ProduitController(IProduitBL produitBL)
        {
            _produitBL = produitBL;
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] ProduitDTO produitDTO)
        {
            return Ok(_produitBL.Post(produitDTO));
        }

        [HttpGet("{id}")]
        public ActionResult<ProduitDTO> GetById(int id)
        {
            return Ok(_produitBL.GetById(id));
        }

        [HttpGet]
        public ActionResult<List<ProduitDTO>> GetAll()
        {
            return Ok(_produitBL.GetAll());
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
