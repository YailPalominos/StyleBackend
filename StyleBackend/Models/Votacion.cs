namespace StyleBackend.Models
{
    public class Votacion
    {
        public int Id { get; set; }
        public int Ronda { get; set; }
        public decimal Total  { get; set; }
        public int RegistroUsuario { get; set; }
        public DateTime RegistroFecha { get; set; }
        public string Patrones { get; set; }
        public string PuntosAdicionales { get; set; }
        public string PuntosRespuesta { get; set; }

        public Votacion()
        {
            Id = 0;
            Ronda = 0;
            Total = 0;
            RegistroUsuario = 0;
            RegistroFecha = new DateTime();
            Patrones = "";
            PuntosAdicionales = "";
            PuntosRespuesta = "";

        }


    }
}
