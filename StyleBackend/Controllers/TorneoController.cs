using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StyleBackend.Models;
using StyleBackend.Models.Modelos;
using StyleBackend.Resources.ConectionSQL;
using System;

namespace StyleBackend.Controllers
{
    [ApiController]
    [Route("Torneos")]
    public class TorneoController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public TorneoController(ConexionSQLServer context) 
        {
            this.context = context; 
        }
       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var oTorneos = context.Torneo.ToList();
                return Ok(oTorneos);
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
                var oTorneoN = new Torneo();
                oTorneoN = context.Torneo.Find(nId);
                return Ok(oTorneoN);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Torneo oTorneo)
        {
            try
            {
                oTorneo.Id = context.Torneo.ToList().Count+1;
                await context.Torneo.AddAsync(oTorneo);
                await context.SaveChangesAsync();
                return Ok(oTorneo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Torneo oTorneo)
        {
            try
            {
               var oTorneoB = context.Torneo.Find(oTorneo.Id);

                if (oTorneoB != null)
                {
                    oTorneoB.Id = oTorneo.Id;
                    oTorneoB.Nombre = oTorneo.Nombre;
                    oTorneoB.Usuarios = oTorneo.Usuarios;
                    oTorneoB.FechaInicioVigencia = oTorneo.FechaInicioVigencia;
                    oTorneoB.FechaFinalVigencia = oTorneo.FechaFinalVigencia;
                    oTorneoB.Tipo = oTorneo.Tipo;
                    oTorneoB.Uso = oTorneo.Uso;
                    oTorneoB.Acomodo = oTorneo.Acomodo;
                    oTorneoB.RegistroUsuario = oTorneo.RegistroUsuario;
                    oTorneoB.FechaRegistro = oTorneo.FechaRegistro;
                    oTorneoB.Descripcion = oTorneo.Descripcion;
                    oTorneoB.Antecesor = oTorneo.Antecesor;
                    oTorneoB.Estado = oTorneo.Estado;

                    await context.SaveChangesAsync();
                    return Ok(oTorneoB);
                }
                else
                {
                    return NotFound("Registro Id("+ oTorneo.Id+ ") no encontrado.");
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
                var oTorneoB = context.Torneo.Find(nId);

                if (oTorneoB != null)
                {
                    context.Remove(oTorneoB);
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
