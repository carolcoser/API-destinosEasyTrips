using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using EasytripAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EasytripAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinosController : ControllerBase
    {
        private readonly DestinosDbContext _context;
        public DestinosController(DestinosDbContext context)
        {
            _context = context;
        }

        //GET: api/Destinos - Lista todos os destinos
        [HttpGet]
        public IEnumerable<Destinos> GetDestinos()
        {
            return _context.Destinos;
        }

        //GET: api/Destinos/id - Lista o destino por ID
        [HttpGet("{id}")]
        public IActionResult GetDestinoPorId(int id)
        {
            Destinos destino = _context.Destinos.SingleOrDefault(modelo => modelo.Id == id);
            if (destino == null)
            {
                return NotFound();
            }
            return new ObjectResult(destino);
        }



        //Post - Cria um novo destino
        [HttpPost]
        public IActionResult CriarDestino(Destinos item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Destinos.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);
        }


        //Put - Atualiza um destino existente
        [HttpPut("{id}")]
        public IActionResult AtualizaDestino(int id, Destinos item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }


        //Delete
        [HttpDelete("{id}")]
        public IActionResult DeletaDestino(int id)
        {
            var destino = _context.Destinos.SingleOrDefault(modelo => modelo.Id == id);

            if (destino == null)
            {
                return BadRequest();
            }

            _context.Destinos.Remove(destino);
            _context.SaveChanges();
            return Ok(destino);
        }
    }
}
