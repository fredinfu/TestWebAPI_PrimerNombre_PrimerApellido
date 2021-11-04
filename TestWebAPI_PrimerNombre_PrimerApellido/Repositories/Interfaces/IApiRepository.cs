using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI_PrimerNombre_PrimerApellido.Models;

namespace TestWebAPI_PrimerNombre_PrimerApellido.Repositories.Interfaces
{
    public interface IApiRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        Task<IEnumerable<Vacuna>> GetVacunasAsync();
        Task<Vacuna> GetVacunaByIdAsync(int id);
        Task<Vacuna> GetVacunaByDescripcion(string descripcion);

        Task<IEnumerable<Dosi>> GetDosisAsync();
        Task<Dosi> GetDosisByIdAsync(int id);
        Task<Dosi> GetDosisByDescripcion(string descripcion);

        Task<IEnumerable<Paciente>> GetPacientesAsync();
        Task<Paciente> GetPacienteByIdAsync(int id);
        Task<Paciente> GetPacientesByExpediente(string expediente);

        Task<IEnumerable<VacunacionCovid19>> GetVacunacionCovid19Async();
        Task<VacunacionCovid19> GetVacunacionCovid19ByIdAsync(int id);
        Task<IEnumerable<VacunacionCovid19>> GetVacunacionCovid19ByPacienteIdAsync(int id);

    }
}
