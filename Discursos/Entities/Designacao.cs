using Discursos.Interfaces;
using Discursos.ValueObjects;

namespace Discursos.Entities
{
    public class Designacao : IDesignacao
    {
        public int Id { get ; set ; }
        public string Descricao { get ; set ; }
        public EDesignacao Codigo { get ; set ; }
    }
}
