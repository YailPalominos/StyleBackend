using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StyleBackend.Models;
using StyleBackend.Models.Modelos;
using StyleBackend.Resources.ConectionSQL;
using System;

namespace StyleBackend.Controllers
{
    [ApiController]
    [Route("Votaciones")]
    public class VotacionController : ControllerBase
    {
        private readonly ConexionSQLServer context;
        public VotacionController(ConexionSQLServer context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var oVotaciones = context.Votacion.ToList();
                return Ok(oVotaciones);
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
                var oVotacionN = new Votacion();
                oVotacionN = context.Votacion.Find(nId);
                return Ok(oVotacionN);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Votacion oVotacion)
        {
            try
            {
                oVotacion.Id = context.Votacion.ToList().Count + 1;
                await context.Votacion.AddAsync(oVotacion);
                await context.SaveChangesAsync();
                return Ok(oVotacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Votacion oVotacion)
        {
            try
            {
                var oVotacionB = context.Votacion.Find(oVotacion.Id);

                if (oVotacionB != null)
                {
                    oVotacionB.Id = oVotacion.Id;
                    oVotacionB.Ronda = oVotacion.Ronda;
                    oVotacionB.Total = oVotacion.Total;
                    oVotacionB.RegistroUsuario = oVotacion.RegistroUsuario;
                    oVotacionB.RegistroFecha = oVotacion.RegistroFecha;
                    oVotacionB.Patrones = oVotacion.Patrones;
                    oVotacionB.PuntosAdicionales = oVotacion.PuntosAdicionales;
                    oVotacionB.PuntosRespuesta = oVotacion.PuntosRespuesta;


                    await context.SaveChangesAsync();
                    return Ok(oVotacionB);
                }
                else
                {
                    return NotFound("Registro Id(" + oVotacion.Id + ") no encontrado.");
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
                var oVotacionB = context.Votacion.Find(nId);

                if (oVotacionB != null)
                {
                    context.Remove(oVotacionB);
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

