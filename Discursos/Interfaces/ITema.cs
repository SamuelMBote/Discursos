using Discursos.Entities;

namespace Discursos.Interfaces
{
    public interface ITema
    {
        int Id { get; set; }
        int Numero { get; set; }
        string Descricao { get; set; }
        int DuracaoEmMinutos { get; set; }
        DateTime AtualizadoEm { get; set; }
        DateTime? UltimaVezEm { get; set; }
        List<Orador>? Oradores { get; set; }
        DateTime? UltimaModificacaoCadastro { get; set; }


    }
}
