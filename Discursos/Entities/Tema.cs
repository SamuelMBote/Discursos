using Discursos.Interfaces;
using Discursos.DataContext;

namespace Discursos.Entities
{
    public class Tema : ITema
    {
        
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Descricao { get; set; }
        public int DuracaoEmMinutos { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public DateTime? UltimaVezEm { get; set; }
        public List<Orador>? Oradores { get ; set ; }

        public DateTime? UltimaModificacaoCadastro { get; set; }
    }

}
