using Consultorio.Dtos;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorio.Repository
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<PacienteDto>> GetPacientesAsync();
        Task<Paciente> GetPacientesByIdAsync(int id);
    }
}
