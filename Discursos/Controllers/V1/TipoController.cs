using Discursos.DataContext;
using Discursos.Entities;
using Discursos.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Discursos.Controllers.V1
{
    [Route("v1/Tipo")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TipoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/<TipoController>
        [HttpGet]
        public async Task<ActionResult<List<Tipo>>> GetAll()
        {
            try
            {
                List<Tipo>? tiposCongregacao = await _context.Tipos.AsNoTracking().ToListAsync();
                if (tiposCongregacao == null || tiposCongregacao.Count <= 0)
                    return NotFound(new { message = "Não há Tipos de Congregação cadastrados" });
                return Ok(new { message = "Lista de Tipos de Congregação Cadastrados", data = tiposCongregacao });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/<TipoController>/5
        [HttpGet("{codigo}")]
        public async Task<ActionResult<List<Tipo>>> Get(ETipoCongregacao codigo)
        {
            try
            {
                Tipo? tipoCongregacao = await _context.Tipos.AsNoTracking().FirstOrDefaultAsync(x => x.Codigo == codigo);
                if (tipoCongregacao == null)
                    return NotFound(new { message = $"Não foi encontrado nenhum Tipo de Congregação com o codigo: {codigo}" });
                return Ok(new { message = "Tipo de Congregação encontrado", data = tipoCongregacao });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
