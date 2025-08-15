using Microsoft.EntityFrameworkCore;
using RVOE.contextos;
using RVOE.modelos.ValidadorModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RVOE.sistemas.ValidadorSistemas
{
    public class EscuelasSistema
    {
        private readonly ValidadorUniversidadesContext _context;

        public EscuelasSistema(ValidadorUniversidadesContext context)
        {
            _context = context;
        }

        // Copiar de modelo a entidad
        public static entidades.ValidadorEntidades.Escuelas CopiarDeModelo(Escuelas modelo)
        {
            return new entidades.ValidadorEntidades.Escuelas
            {
                EscuelaId = modelo.EscuelaId == Guid.Empty ? Guid.NewGuid() : modelo.EscuelaId,
                NombreEscuela = modelo.NombreEscuela,
                NoExpendiente = modelo.NoExpendiente,
                CCT = modelo.CCT,
                RepresentanteLegal = modelo.RepresentanteLegal,
                SociedadCivil = modelo.SociedadCivil,
                Direccion = modelo.Direccion,
                Municipio = modelo.Municipio,
                Nivel = modelo.Nivel,
                Modalidad = modelo.Modalidad,
                PSU = modelo.PSU,
                FechaIncorporacion = modelo.FechaIncorporacion,
                EstatusId = modelo.EstatusId,
                ConvenioSalud = modelo.ConvenioSalud,
                Telefono = modelo.Telefono,
                Correo = modelo.Correo,
                Observaciones = modelo.Observaciones,
                TipoEscuelaId = modelo.TipoEscuelaId
            };
        }

        // Copiar de entidad a modelo
        public static Expression<Func<entidades.ValidadorEntidades.Escuelas, Escuelas>> CopiarDeEntidad => e =>
            new Escuelas
            {
                EscuelaId = e.EscuelaId,
                NombreEscuela = e.NombreEscuela,
                NoExpendiente = e.NoExpendiente,
                CCT = e.CCT,
                RepresentanteLegal = e.RepresentanteLegal,
                SociedadCivil = e.SociedadCivil,
                Direccion = e.Direccion,
                Municipio = e.Municipio,
                Nivel = e.Nivel,
                Modalidad = e.Modalidad,
                PSU = e.PSU,
                FechaIncorporacion = e.FechaIncorporacion,
                EstatusId = e.EstatusId,
                ConvenioSalud = e.ConvenioSalud,
                Telefono = e.Telefono,
                Correo = e.Correo,
                Observaciones = e.Observaciones,
                TipoEscuelaId = e.TipoEscuelaId,
                TipoEscuela = e.TipoEscuela == null ? null : new TiposEscuela
                {
                    TipoEscuelaId = e.TipoEscuela.TipoEscuelaId,
                    NombreTipo = e.TipoEscuela.NombreTipo,
                    Descripcion = e.TipoEscuela.Descripcion
                }
            };

        // Agregar
        public async Task<string> AgregarAsync(Escuelas modelo)
        {
            var entidad = CopiarDeModelo(modelo);
            _context.Escuelas.Add(entidad);
            await _context.SaveChangesAsync();
            return "Escuela agregada correctamente.";
        }

        // Actualizar
        public async Task<string> ActualizarAsync(Escuelas modelo)
        {
            var entidad = await _context.Escuelas.FirstOrDefaultAsync(e => e.EscuelaId == modelo.EscuelaId);
            if (entidad == null) return "La escuela no existe.";

            entidad.NombreEscuela = modelo.NombreEscuela;
            entidad.NoExpendiente = modelo.NoExpendiente;
            entidad.CCT = modelo.CCT;
            entidad.Municipio = modelo.Municipio;
            entidad.TipoEscuelaId = modelo.TipoEscuelaId;

            await _context.SaveChangesAsync();
            return "Escuela actualizada correctamente.";
        }

        // Eliminar
        public async Task<string> EliminarAsync(Guid id)
        {
            var entidad = await _context.Escuelas.FirstOrDefaultAsync(e => e.EscuelaId == id);
            if (entidad == null) return "Escuela no encontrada.";

            _context.Escuelas.Remove(entidad);
            await _context.SaveChangesAsync();
            return "Escuela eliminada correctamente.";
        }

        // Obtener una
        public async Task<Escuelas?> ObtenerAsync(Guid id)
        {
            return await _context.Escuelas
                .Include(e => e.TipoEscuela)
                .AsNoTracking()
                .Select(CopiarDeEntidad)
                .FirstOrDefaultAsync(e => e.EscuelaId == id);
        }

        // Obtener todas
        public async Task<List<Escuelas>> ObtenerTodasAsync()
        {
            return await _context.Escuelas
                .Include(e => e.TipoEscuela)
                .AsNoTracking()
                .Select(CopiarDeEntidad)
                .ToListAsync();
        }
    }
}
