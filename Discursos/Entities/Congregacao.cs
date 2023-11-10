using Discursos.Interfaces;

namespace Discursos.Entities
{
    public class Congregacao : ICongregacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public int TipoId { get; set; }
        public Tipo? Tipo { get; set; }
        public int? CoordenadoraId { get; set; }
        public virtual Congregacao? Coordenadora { get; set; }
        public virtual List<Orador>? OradoresDaCongregacao {  get; set; }
        
    }
}
