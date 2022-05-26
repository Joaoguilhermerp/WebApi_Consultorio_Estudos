using AutoMapper;
using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _repository;
        private readonly IMapper _mapper;

        public EspecialidadeController(IEspecialidadeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var especialidades = await _repository.GetEspecialidades();
            return especialidades.Any()
                ? Ok(especialidades)
                : NotFound("Especialidades não encontradas");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest("Dados invalidos.");

            var especialidade = await _repository.GetEspecialidadeById(id);

            var especialidadeRetorno = _mapper.Map<EspecialiadadeDetalhesDto>(especialidade);

            return especialidadeRetorno != null
                ? Ok(especialidadeRetorno)
                : NotFound("Especialidades não encontradas");
        }

        [HttpPost]
        public async Task<IActionResult> Post(EspecialidadeAdctionarDto especialidade)
        {
            if (string.IsNullOrEmpty(especialidade.Nome)) return BadRequest("Nome invalido");

            var especialidadeAdcionar = new Especialidade
            {
                Nome = especialidade.Nome,
                Ativa = especialidade.Ativa,
            };

            _repository.Add(especialidadeAdcionar);

            return await _repository.SaveChangesAsync()
                ? Ok("Especialidade adicionado com sucesso")
                : BadRequest(" Erro ao adicionar especialidade");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, bool ativo)
        {
            if (id <= 0) return BadRequest("Especialidade invalida.");

            var especialidade = await _repository.GetEspecialidadeById(id);

            if (especialidade == null) return NotFound("Especialidae não existe na base de dados");

            string status = ativo ? "ativa" : "inativa";
            if (especialidade.Ativa == ativo) return Ok("A especialidade já está " + status);

            especialidade.Ativa = ativo;

            _repository.Update(especialidade);

            return await _repository.SaveChangesAsync()
                ? Ok("Status atualizado")
                : BadRequest("Erro ao atualizar status");
        }

       
    }
}
