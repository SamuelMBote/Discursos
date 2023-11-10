using Discursos.Interfaces;
using Discursos.ValueObjects;

namespace Discursos.Entities
{
    public class Tipo : ITipo
    {
        public int Id { get; set; }
        public ETipoCongregacao Codigo { get; set; }
        public string Descricao { get; set; }

            }
}
