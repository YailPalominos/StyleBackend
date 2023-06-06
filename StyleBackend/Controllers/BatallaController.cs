using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StyleBackend.Models;
using StyleBackend.Models.Modelos;
using StyleBackend.Resources.ConectionSQL;
using System;


namespace StyleBackend.Controllers
{
    [ApiController]
    [Route("Batallas")]
    public class BatallaController : ControllerBase
    {
        private readonly ConexionSQLServer context;
        public BatallaController(ConexionSQLServer context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var oBatallas = context.Batalla.ToList();
                return Ok(oBatallas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOne/{nId:int}")]
        public async Task<IActionResult> GetOne(int nId)
        {
            try
            {
                var oBatalla = new Batalla();
                oBatalla = context.Batalla.Find(nId);
                return Ok(oBatalla);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Batalla oBatalla)
        {
            try
            {
                oBatalla.Id = context.Batalla.ToList().Count + 1;
                await context.Batalla.AddAsync(oBatalla);
                await context.SaveChangesAsync();
                return Ok(oBatalla);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Batalla oBatalla)
        {
            try
            {
                var oBatallaB = context.Batalla.Find(oBatalla.Id);

                if (oBatallaB != null)
                {
                    oBatallaB.Id = oBatalla.Id;
                    oBatallaB.F1 = oBatalla.F1;
                    oBatallaB.F2 = oBatalla.F2;
                    oBatallaB.Replicas = oBatalla.Replicas;
                    oBatallaB.Ganador = oBatalla.Ganador;

                    await context.SaveChangesAsync();
                    return Ok(oBatallaB);
                }
                else
                {
                    return NotFound("Registro Id(" + oBatalla.Id + ") no encontrado.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{nId:int}")]
        public async Task<IActionResult> Delete(int nId)
        {
            try
            {
                var oBatalla = context.Batalla.Find(nId);

                if (oBatalla != null)
                {
                    context.Remove(oBatalla);
                    await context.SaveChangesAsync();
                    return Ok("Registro Id(" + nId + ") eliminado.");
                }
                else
                {
                    return NotFound("Registro Id(" + nId + ") no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}