namespace generic.mvc.domain.Entities
{
    public class Potro : Base
    {
        public string Titulo1 { get; set; }

        public string Titulo2 { get; set; }

        public Potro()
        {
            
        }

        public Potro(string Titulos1, string Titulos2)
        {
            this.Titulo1 = Titulo1;
            this.Titulo2 = Titulo2;
        }
    }
}