using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StyleBackend.Models.Modelos
{
    public class SuperUsuario
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public DateTime RegistroFecha { get; set; }
        public string Permisos { get; set; }

        public SuperUsuario() {
            Id = 0;
            Usuario = "";
            Contraseña = "";
            RegistroFecha = new DateTime();
            Permisos = "";
    }
    }
}
