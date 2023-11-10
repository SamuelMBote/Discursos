using Discursos.Entities;
using Discursos.ValueObjects;

namespace Discursos.Interfaces
{
    public interface ITipo
    {
        int Id { get; set; }
        ETipoCongregacao Codigo { get; set; }
        string Descricao { get; set; }
                

    }
}
