using Discursos.Entities;

namespace Discursos.Interfaces
{
    public interface ICongregacao
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Cidade { get; set; }
        string UF { get; set; }
        int TipoId { get; set; }
        Tipo? Tipo { get; set; }
        int? CoordenadoraId { get; set; }
        Congregacao? Coordenadora { get; set; }
        List<Orador>? OradoresDaCongregacao { get; set; }    
            }
}
