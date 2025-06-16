using Api.CompliCheck.Services;
using Api.CompliCheck.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.CompliCheck.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaExibicaoDto>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var empresas = await _empresaService.ListarAsync(pageNumber, pageSize);
            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaExibicaoDto>> GetById(int id)
        {
            var empresa = await _empresaService.BuscarPorIdAsync(id);
            if (empresa == null)
                return NotFound();

            return Ok(empresa);
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaExibicaoDto>> Create(EmpresaCadastroDto dto)
        {
            var empresaCriada = await _empresaService.CadastrarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = empresaCriada.Id }, empresaCriada);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmpresaExibicaoDto>> Update(int id, EmpresaCadastroDto dto)
        {
            var empresaAtualizada = await _empresaService.AtualizarAsync(id, dto);
            if (empresaAtualizada == null)
                return NotFound();

            return Ok(empresaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _empresaService.DeletarAsync(id);
            if (!deletado)
                return NotFound();

            return NoContent();
        }
    }
}
