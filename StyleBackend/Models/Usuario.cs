using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StyleBackend.Models.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Pais { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Amigos { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string CorreoElectronico { get; set; }
        public char Sexo { get; set; }

        public Usuario()
        {
            Id=0;
            Nombres = "";
            Apellidos = "";
            NombreUsuario = "";
            Contraseña = "";
            Pais = "";
            FechaNacimiento = new DateTime();
            Amigos = "";
            FechaRegistro = new DateTime();
            CorreoElectronico = "";
            Sexo = 'N';
        }
    }
     
   
}
