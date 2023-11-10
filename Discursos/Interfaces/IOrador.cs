using Discursos.Entities;

namespace Discursos.Interfaces
{
    public interface IOrador
    {
        int Id { get; set; }
        string Nome { get; set; }
        List<Tema>? Temas { get; set; }
        int CongregacaoId { get; set; }
        Congregacao? Congregacao { get; set; }
        int DesignacaoId { get; set; }
        Designacao? Designacao { get; set; }
        DateTime? UltimaVezEm { get; set; }

    }
}
