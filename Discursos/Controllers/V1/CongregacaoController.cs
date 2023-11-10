using Discursos.DataContext;
using Discursos.Entities;
using Discursos.ValueObjects;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;


// For more information on enabling Web v1 for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Discursos.Controllers.V1
{
    [Route("v1/Congregacao")]
    [ApiController]
    public class CongregacaoController : ControllerBase

    {
        private readonly DatabaseContext _context;

        public CongregacaoController(DatabaseContext context)
        {
            _context = context;
        }


        // GET: v1/<CongregacaoController>
        [HttpGet]
        public async Task<ActionResult<List<Congregacao>>> GetAll()
        {
            try
            {
                List<Congregacao>? congregacaoes = await _context.Congregacoes.Include(x => x.Tipo).Include(x => x.OradoresDaCongregacao).Include(x=>x.Coordenadora).ToListAsync();
                if (congregacaoes == null || congregacaoes.Count <= 0)
                    return NotFound(new { message = "Não há Congregações cadastradas" });
                return Ok(new { message = "Lista de Congregações", data = congregacaoes });
            }
            catch (Exception ex)
            {

                return BadRequest(new { messsage = ex.Message });
            }
        }

        // GET v1/<CongregacaoController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Congregacao>> Get(int id)
        {
            try
            {
                Congregacao? congregacao = await _context.Congregacoes.AsNoTracking().Include(x => x.Tipo).Include(x => x.OradoresDaCongregacao).Include(x=>x.Coordenadora).FirstOrDefaultAsync(x => x.Id == id);
                if (congregacao == null)
                    return NotFound(new { message = $"Não foi encontrada nenhuma Congregação com o Id: {id}" });
                return Ok(new { message = "Congregação encontrada", data = congregacao });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        // POST v1/<CongregacaoController>
        [HttpPost]
        public async Task<ActionResult<Congregacao>> Post(Congregacao model)
        {
                  try
            {
                Congregacao? congregacao = await _context.Congregacoes.Where(x => x.Nome == model.Nome && x.Cidade == model.Cidade && x.UF == model.UF).FirstOrDefaultAsync();
                if(congregacao == null)
                {
                    if(model.CoordenadoraId == null) {
                        _context.Congregacoes.Add(model);
                        await _context.SaveChangesAsync();
                        return Ok(new { message = "Congregação cadastrada com sucesso", data = model });
                    }
                    else if (model.TipoId == 3 && model.CoordenadoraId != null)
                    {

                        return BadRequest(new { message = "Uma congregação não pode pertencer a outra" });
                    }
                    else
                    {
                        Congregacao? coordenadora = await _context.Congregacoes.Include(x=>x.Tipo).FirstOrDefaultAsync(x => x.Id == model.CoordenadoraId);
                        if(coordenadora == null)
                        {
                            return BadRequest(new {message=$"Não foi possível cadastrar. Não existe congregacao com id {model.CoordenadoraId} para servir como Coordenadora"});
                        
                        }else if(coordenadora.TipoId == 1 || coordenadora.TipoId == 2) {

                            return BadRequest(new { message = $"Não é possivel incluir o {coordenadora.Tipo?.Descricao} {coordenadora.Nome} de {coordenadora.Cidade}, {coordenadora.UF} como congregação coordenadora" });

                        }
                        else
                        {
                            _context.Congregacoes.Add(model);
                            await _context.SaveChangesAsync();
                            return Ok(new { message = "Congregação cadastrada com sucesso", data = model });
                        }

                    }
                    
                }
                else
                {
                    return StatusCode(405, new { message = $"Já existe uma congreção: {model.Nome}, em {model.Cidade}/{model.UF}" });
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

        // PUT v1/<CongregacaoController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Congregacao>> Put(int id,Congregacao model)
        {
            try
            {

                Congregacao? congregacao = await _context.Congregacoes.FirstOrDefaultAsync(x => x.Id == id);

                if (congregacao == null || congregacao.Id != id)
                {

                    return NotFound(new { message = $"Não foi possível encontrar congregação com id igual a {id}" });
                }
                else if (congregacao.Nome != model.Nome || congregacao.Cidade != model.Cidade || congregacao.UF != model.UF)
                {
                    return StatusCode(405, new { message = "O Nome, Cidade e UF devem ser únicos. Ao invés de alterar, remova esse cadastro e insira um correto." });
                }
                else
                {

                    congregacao.TipoId = model.TipoId;
                    congregacao.Tipo = model.Tipo;
                    congregacao.CoordenadoraId = model.CoordenadoraId;
                    congregacao.OradoresDaCongregacao = model.OradoresDaCongregacao;

                    try
                    {
                        await _context.SaveChangesAsync();
                        return Ok(new { message = $"Congregação com id {id} atualizada com sucesso", data = congregacao });
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

        // DELETE v1/<CongregacaoController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Congregacao>> Delete(int id)
        {
            try
            {
                Congregacao? congregacao = await _context.Congregacoes.FirstOrDefaultAsync(x => x.Id == id);

                if (congregacao == null || congregacao.Id != id)
                {
                    return NotFound(new { message = $"Não foi possivel deletar, não há congregação com id {id}" });
                }
                else
                {
                    _context.Congregacoes.Remove(congregacao);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Congregação deletada", data = congregacao });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, inner = ex.InnerException?.Message });
            }

        }

    }
}
