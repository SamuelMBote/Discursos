using Discursos.Interfaces;

namespace Discursos.Entities
{
    public class Orador : IOrador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Tema>? Temas { get; set; }
        public int CongregacaoId { get; set; }
        public virtual Congregacao? Congregacao { get; set; }
        public int DesignacaoId { get ; set ; }
        public virtual Designacao? Designacao { get ; set ; }
        public DateTime? UltimaVezEm { get ; set ; }
    }
}
