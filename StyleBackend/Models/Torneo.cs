namespace StyleBackend.Models
{
    public class Torneo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuarios { get; set; }
        public DateTime FechaInicioVigencia { get; set; }
        public DateTime FechaFinalVigencia { get; set; }
        public char Tipo { get; set; }
        public string Uso { get; set; }
        public string Acomodo { get; set; }
        public int RegistroUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Descripcion { get; set; }
        public int Antecesor { get; set; }
        public char Estado { get; set; }


        public Torneo() {

        Id = 0;
        Nombre = "";
        Usuarios = "";
        FechaInicioVigencia = new DateTime();
        FechaFinalVigencia = new DateTime();
        Tipo = 'N';
        Uso = "NA";
        Acomodo = "NA";
        RegistroUsuario = 0;
        FechaRegistro = new DateTime();
        Descripcion = "";
        Antecesor = 0;
        Estado = 'N';

    }


}
}
