using Discursos.Interfaces;

namespace Discursos.Entities
{
    public class Programacao : IProgramacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int OradorId { get; set; }
        public Orador Orador { get; set; }
        public int TemaId { get; set; }
        public Tema Tema { get; set; }
    }
}
