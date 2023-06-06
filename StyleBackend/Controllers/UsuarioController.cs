using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StyleBackend.Models.Modelos;
using StyleBackend.Resources.ConectionSQL;
using System;

namespace StyleBackend.Controllers
{
    [ApiController]
    [Route("Usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public UsuarioController(ConexionSQLServer context) 
        {
            this.context = context; 
        }
       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var oUsuarios = context.Usuario.ToList();
                return Ok(oUsuarios);
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
                var oUsuarioN = new Usuario();
                oUsuarioN = context.Usuario.Find(nId);
                return Ok(oUsuarioN);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Usuario oUsuario)
        {
            try
            {
                oUsuario.Id = context.Usuario.ToList().Count+1;
                await context.Usuario.AddAsync(oUsuario);
                await context.SaveChangesAsync();
                return Ok(oUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Usuario oUsuario)
        {
            try
            {
               var oUsuarioB = context.Usuario.Find(oUsuario.Id);

                if (oUsuarioB != null)
                {
                    oUsuarioB.Id = oUsuario.Id;
                    oUsuarioB.Nombres = oUsuario.Nombres;
                    oUsuarioB.Apellidos = oUsuario.Apellidos;
                    oUsuarioB.NombreUsuario = oUsuario.NombreUsuario;
                    oUsuarioB.Contraseña = oUsuario.Contraseña;
                    oUsuarioB.Pais = oUsuario.Pais;
                    oUsuarioB.FechaNacimiento = oUsuario.FechaNacimiento;
                    oUsuarioB.Amigos = "";
                    oUsuarioB.FechaRegistro = oUsuario.FechaRegistro;
                    oUsuarioB.CorreoElectronico = oUsuario.CorreoElectronico;
                    oUsuarioB.Sexo = oUsuario.Sexo;
                    await context.SaveChangesAsync();
                    return Ok(oUsuarioB);
                }
                else
                {
                    return NotFound("Registro Id("+ oUsuario.Id+ ") no encontrado.");
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
                var oUsuarioB = context.Usuario.Find(nId);

                if (oUsuarioB != null)
                {
                    context.Remove(oUsuarioB);
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
