using Discursos.Entities;

namespace Discursos.Interfaces
{
    public interface IProgramacao
    {
        int Id { get; set; }
        DateTime Data { get; set; }
        int OradorId { get; set; }
        Orador Orador { get; set; }
        int TemaId { get; set; }
        Tema Tema { get; set; }
    }
}
