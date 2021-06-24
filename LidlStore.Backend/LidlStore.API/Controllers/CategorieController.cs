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
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieBL _categorieBL;
        public CategorieController(ICategorieBL categorieBL)
        {
            _categorieBL = categorieBL;
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] CategorieDTO categorieDTO)
        {
            return Ok(_categorieBL.Post(categorieDTO));
        }

        [HttpGet("{id}")]
        public ActionResult<CategorieDTO> GetById(int id)
        {
            try
            {
                return Ok(_categorieBL.GetById(id));
            }
            catch (NotFoundException e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<CategorieDTO>> GetAll()
        {
            try
            {
                return Ok(_categorieBL.GetAll());
            }
            catch (NotFoundException e)
            {

                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_categorieBL.Delete(id));
        }

        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] CategorieDTO categorieDTO)
        {
            if (id != categorieDTO.Id) return BadRequest();

            return _categorieBL.Put(categorieDTO);
        }
    }
}
