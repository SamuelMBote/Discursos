using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Discursos.DataContext;
using Discursos.Entities;

namespace Discursos.Controllers.V1
{
    [Route("v1/Orador")]
    [ApiController]
    public class OradorController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public OradorController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: v1/Orador
        [HttpGet]
        public async Task<ActionResult<List<Orador>>> GetOradores()
        {
            try
            {
                List<Orador>? oradores = await _context.Oradores.AsNoTracking().Include(x => x.Temas).Include(x=>x.Congregacao).Include(x=>x.Designacao).ToListAsync();
                if (oradores == null || oradores.Count == 0)
                    return NotFound(new { message = "Não há oradores cadastrados" });
                return Ok(new { message = "Lista de oradores cadastrados", data = oradores });
            }
            catch (Exception ex)
            {

                return BadRequest(new { messsage = ex.Message });
            }
        }

        // GET: v1/Orador/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Orador>> GetOrador(int id)
        {
            try
            {
                Orador? orador = await _context.Oradores.AsNoTracking().Include(x => x.Temas).Include(x => x.Congregacao).Include(x => x.Designacao).FirstOrDefaultAsync(x => x.Id == id);
                if (orador == null)
                    return NotFound(new { message = $"Não foi encontrado nenhum orador com o id: {id}" });
                return Ok(new { message = "Orador encontrado", data = orador });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: v1/Orador/5
        [HttpGet("{id:int}/Temas")]
        public async Task<ActionResult<Orador>> GetTemasOrador(int id)
        {
            try
            {
                Orador? orador = await _context.Oradores.AsNoTracking().Include(x => x.Temas).FirstOrDefaultAsync(x => x.Id == id);
                if (orador == null)
                    return NotFound(new { message = $"Não foi encontrado nenhum orador com o id: {id}" });
                return Ok(new { message = "Orador encontrado", data = orador.Temas });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }


        // POST: v1/Orador
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orador>> PostOrador(Orador model)
        {
            try
            {
                if(model.DesignacaoId == 0)
                {
                    return BadRequest(new { message = "Informe qual a designação do orador" });
                }
                else {
                    _context.Oradores.Add(model);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Congregação cadastrada com sucesso", data = model });

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

        // PUT: v1/Orador/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Orador>> PutOrador(int id, Orador model)
        {
            try
            {

                Orador? orador = await _context.Oradores.FirstOrDefaultAsync(x => x.Id == id);

                if (orador == null || orador.Id != id)
                {

                    return NotFound(new { message = $"Não foi possível encontrar orador com o id: {id}" });
                }
                
                else
                {

                    orador.Nome = model.Nome;
                    orador.Temas = model.Temas;
                    orador.Designacao = model.Designacao;
                    orador.DesignacaoId = model.DesignacaoId;
                    orador.CongregacaoId = model.CongregacaoId;
                    orador.Congregacao = model.Congregacao;
                        
                    try
                    {
                        await _context.SaveChangesAsync();
                        return Ok(new { message = $"Orador com id {id} atualizado com sucesso", data = orador });
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

       

        // DELETE: v1/Orador/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Orador>> DeleteOrador(int id)
        {
            try
            {
                Orador? orador = await _context.Oradores.FirstOrDefaultAsync(x => x.Id == id);

                if (orador == null || orador.Id != id)
                {
                    return NotFound(new { message = $"Não foi possivel deletar, não há orador com id {id}" });
                }
                else
                {
                    _context.Oradores.Remove(orador);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Orador deletado", data = orador });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, inner = ex.InnerException?.Message });
            }
        }

    
    }
}
