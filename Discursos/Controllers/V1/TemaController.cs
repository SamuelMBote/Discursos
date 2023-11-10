using Discursos.DataContext;
using Discursos.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Discursos.Controllers.V1
{
    [Route("v1/Tema")]
    [ApiController]
    public class TemaController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TemaController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Tema
        [HttpGet]
        public async Task<ActionResult<List<Tema>>> GetTemas()
        {
            try
            {
                List<Tema>? temas = await _context.Temas.AsNoTracking().Include(x => x.Oradores).ToListAsync();
                if (temas == null || temas.Count == 0)
                    return NotFound(new { message = "Não há Temas cadastrados" });
                return Ok(new { message = "Lista de temas cadastrados", data = temas });
            }
            catch (Exception ex)
            {

                return BadRequest(new { messsage = ex.Message });
            }
        }

        // GET: api/Tema/5
        [HttpGet("{numero:int}")]
        public async Task<ActionResult<Tema>> GetTema(int numero)
        {
            try
            {
                Tema? tema = await _context.Temas.AsNoTracking().Include(x => x.Oradores).FirstOrDefaultAsync(x => x.Numero == numero);
                if (tema == null)
                    return NotFound(new { message = $"Não foi encontrado nenhum Tema com o numero: {numero}" });
                return Ok(new { message = "Tema encontrado", data = tema });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Tema
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tema>> PostTema(Tema model)
        {
            try
            {
                Tema? tema = await _context.Temas.Where(x => x.Numero == model.Numero).FirstOrDefaultAsync();
                if (tema == null)
                {
                    _context.Temas.Add(model);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Congregação cadastrada com sucesso", data = model });
                }
                else
                {
                    return StatusCode(405, new { message = $"O discurso {model.Numero} já está cadastrado " });
                }
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { message = ex.Message, inner = ex.InnerException?.Message });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, inner = ex.InnerException?.Message });
            }
        }


        // PUT: api/Tema/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{numero:int}")]
        public async Task<ActionResult<Tema>> PutTema(int numero, Tema model)
        {
            try
            {

                Tema? tema = await _context.Temas.FirstOrDefaultAsync(x => x.Numero == numero);

                if (tema == null || tema.Numero != numero)
                {

                    return NotFound(new { message = $"Não foi possível encontrar tema com o numero: {numero}" });
                }
                else if (tema.Numero != model.Numero)
                {
                    return StatusCode(405, new { message = "O número do discurso não pode ser alterado." });
                }
                else
                {

                    tema.Descricao = model.Descricao;
                    tema.DuracaoEmMinutos = model.DuracaoEmMinutos;
                    tema.AtualizadoEm = model.AtualizadoEm;
                    tema.Oradores = model.Oradores;

                    try
                    {
                        await _context.SaveChangesAsync();
                        return Ok(new { message = $"Tema de número {numero} atualizado com sucesso", data = tema });
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        return BadRequest(new { message = ex.Message, inner = ex.InnerException?.Message });
                    }

                    catch (Exception ex)
                    {
                        return BadRequest(new { message = ex.Message, inner = ex.InnerException?.Message });
                    }

                }

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, inner = ex.InnerException?.Message });
            }
        }



    }
}
