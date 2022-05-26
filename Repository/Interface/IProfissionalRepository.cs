using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorio.Repository.Interface
{
    public interface IProfissionalRepository : IBaseRepository
    {
        Task<IEnumerable<ProfissionalDto>> GetProfissionais();
        Task<Profissional> GetProfissionalById(int id);
        Task<ProfissionalEspecialidade> GetProfissionalEspecialidade(int profissionalId, int especialidadeId);
    }
}
