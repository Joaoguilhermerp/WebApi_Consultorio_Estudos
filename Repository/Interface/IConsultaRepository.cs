using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consultorio.Repository.Interface
{
    public interface IConsultaRepository : IBaseRepository
    {
        Task<IEnumerable<Consulta>> GetConsultas(ConsultaParams parametros);
        Task<Consulta> GetConsultaById(int id);
    }
}
