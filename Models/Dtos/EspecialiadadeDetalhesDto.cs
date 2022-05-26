using Consultorio.Models.Entities;
using System.Collections.Generic;

namespace Consultorio.Models.Dtos
{
    public class EspecialiadadeDetalhesDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set;}
        public List<ProfissionalDto> Profissionais { get; set;}
    }
}
