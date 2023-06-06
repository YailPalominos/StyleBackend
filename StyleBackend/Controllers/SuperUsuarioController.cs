using Microsoft.AspNetCore.Mvc;
using StyleBackend.Resources.ConectionSQL;

namespace StyleBackend.Controllers
{
    [ApiController]
    [Route("api/SuperUsuarios")]
    public class SuperUsuario : ControllerBase
    {

        private readonly ConexionSQLServer context;

        public SuperUsuario(ConexionSQLServer context) 
        {
            this.context = context; 
        }
       
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var oUsuarios = context.SuperUsuario.ToList(); 
                return Ok(oUsuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        }
    }
