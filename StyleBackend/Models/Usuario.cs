namespace StyleFrontend.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string FechaNacimiento { get; set; }
        public string Amigos { get; set; }
        public string CorreoElectronico { get; set; }
        public string FechaRegistro { get; set; }

        public Usuario()
        {
            Id=0;
            Nombres = "";
            Apellidos = "";
            NombreUsuario = "";
            Contraseña = "";
            Pais = "";
            Estado = "";
            FechaNacimiento = "";
            Amigos = "";
            CorreoElectronico = "";
            FechaRegistro = "";
        }

    }
   
}
