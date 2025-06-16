using Api.CompliCheck.Services;
using Api.CompliCheck.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.CompliCheck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NormaController : ControllerBase
    {
        private readonly INormaService _normaService;

        public NormaController(INormaService normaService)
        {
            _normaService = normaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NormaExibicaoDto>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var normas = await _normaService.ListarAsync(pageNumber, pageSize);
            return Ok(normas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NormaExibicaoDto>> GetById(int id)
        {
            var norma = await _normaService.BuscarPorIdAsync(id);
            if (norma == null)
                return NotFound();

            return Ok(norma);
        }

        [HttpPost]
        public async Task<ActionResult<NormaExibicaoDto>> Create(NormaCadastroDto dto)
        {
            var normaCriada = await _normaService.CadastrarAsync(dto);
            if (normaCriada == null)
                return BadRequest("Empresa vinculada não encontrada");

            return CreatedAtAction(nameof(GetById), new { id = normaCriada.Id }, normaCriada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NormaExibicaoDto>> Update(int id, NormaCadastroDto dto)
        {
            var normaAtualizada = await _normaService.AtualizarAsync(id, dto);
            if (normaAtualizada == null)
                return NotFound();

            return Ok(normaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _normaService.DeletarAsync(id);
            if (!deletado)
                return NotFound();

            return NoContent();
        }
    }
}
