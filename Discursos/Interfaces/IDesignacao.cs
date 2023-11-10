using Discursos.ValueObjects;

namespace Discursos.Interfaces
{
    public interface IDesignacao
    {
        int Id { get; set; }
        EDesignacao Codigo { get; set; }

        string Descricao { get; set; }
    }
}
