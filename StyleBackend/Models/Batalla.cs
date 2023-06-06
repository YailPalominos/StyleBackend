namespace StyleBackend.Models
{
    public class Batalla
    {
        public int Id { get; set; }
        public int Torneo { get; set; }
        public int F1 { get; set; }
        public int F2 { get; set; }
        public int Replicas { get; set; }
        public int Ganador { get; set; }

        public Batalla()
        {
            Id = 0;
            Torneo = 0;
            F1= 0;
            F2 = 0;
            Replicas = 0;
            Ganador = 0;
        }

    }
}
