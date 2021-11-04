using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI_PrimerNombre_PrimerApellido.Models;
using TestWebAPI_PrimerNombre_PrimerApellido.Repositories.Interfaces;

namespace TestWebAPI_PrimerNombre_PrimerApellido.Repositories
{
    public class ApiRepository : IApiRepository
    {
        private readonly TestWebAPI_PrimerNombre_PrimerApellidoContext _context;
        public ApiRepository(TestWebAPI_PrimerNombre_PrimerApellidoContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Dosi>> GetDosisAsync()
        {
            var dosis = await _context.Doses.ToListAsync();
            return dosis;
        }

        public async Task<Dosi> GetDosisByDescripcion(string descripcion)
        {
            var dosi = await _context.Doses.FirstOrDefaultAsync(d => d.Descripcion == descripcion);
            return dosi;
        }

        public async Task<Dosi> GetDosisByIdAsync(int id)
        {
            var dosi = await _context.Doses.FirstOrDefaultAsync(d => d.DosisVacunaId == id);
            return dosi;
        }

        public async Task<IEnumerable<Paciente>> GetPacientesAsync()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return pacientes;
        }

        public async Task<Paciente> GetPacientesByExpediente(string expediente)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.Expediente == expediente);
            return paciente;
        }

        public async Task<Paciente> GetPacientesByIdAsync(int id)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.PacienteId == id);
            return paciente;
        }

        public async Task<Vacuna> GetVacunaByDescripcion(string descripcion)
        {
            var vacuna = await _context.Vacunas.FirstOrDefaultAsync(v => v.Descripcion == descripcion);
            return vacuna;
        }

        public async Task<Vacuna> GetVacunaByIdAsync(int id)
        {
            var vacuna = await _context.Vacunas.FirstOrDefaultAsync(p => p.VacunaId == id);
            return vacuna;
        }

        public Task<IEnumerable<VacunacionCovid19>> GetVacunacionCovid19Async()
        {
            throw new NotImplementedException();
        }

        public Task<VacunacionCovid19> GetVacunacionCovid19ByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VacunacionCovid19>> GetVacunacionCovid19ByPacienteIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vacuna>> GetVacunasAsync()
        {
            var vacunas = await _context.Vacunas.ToListAsync();
            return vacunas;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
