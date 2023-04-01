using Microsoft.AspNetCore.Mvc;
using StyleFrontend.Modelos;

namespace StyleBackend.Controllers
{

    public class UsuarioController : Controller
    {

        
        [HttpGet("{nId:int}")]
        public async Task<IActionResult> Get(int nId)
        {
            try
            {
                var oUsuario=new Usuario();

                return Ok(oUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
