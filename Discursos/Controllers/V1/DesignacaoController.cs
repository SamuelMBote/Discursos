using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Discursos.DataContext;
using Discursos.Entities;
using Discursos.ValueObjects;

namespace Discursos.Controllers.V1
{
    [Route("v1/Designacao")]
    [ApiController]
    public class DesignacaoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public DesignacaoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Designacao
        [HttpGet]
        public async Task<ActionResult<List<Designacao>>> GetDesignacoes()
        {
            try
            {
                List<Designacao>? designacoes = await _context.Designacoes.AsNoTracking().ToListAsync();
                if (designacoes == null || designacoes.Count <= 0)
                    return NotFound(new { message = "Não há designações cadastradas" });
                return Ok(new { message = "Lista de Tipos de Designação Cadastrados", data = designacoes });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Designacao/5
        [HttpGet("{codigo}")]
        public async Task<ActionResult<Designacao>> GetDesignacao(EDesignacao codigo)
        {
            try
            {
                Designacao? designacao = await _context.Designacoes.AsNoTracking().FirstOrDefaultAsync(x => x.Codigo == codigo);
                if (designacao == null)
                    return NotFound(new { message = $"Não foi encontrada nenhuma designação com o codigo: {codigo}" });
                return Ok(new { message = "Tipo de Designação encontrada", data = designacao });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }


      

    }
}
