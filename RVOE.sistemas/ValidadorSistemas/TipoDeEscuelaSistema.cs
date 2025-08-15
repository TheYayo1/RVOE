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
    public class TipoDeEscuelaSistemas
    {
        private readonly ValidadorUniversidadesContext _context;

        public TipoDeEscuelaSistemas(ValidadorUniversidadesContext context)
        {
            _context = context;
        }

        // Copiar de modelo a entidad
        public static entidades.ValidadorEntidades.TiposEscuela CopiarDeModelo(TiposEscuela modelo)
        {
            return new entidades.ValidadorEntidades.TiposEscuela
            {
                TipoEscuelaId = modelo.TipoEscuelaId == Guid.Empty ? Guid.NewGuid() : modelo.TipoEscuelaId,
                NombreTipo = modelo.NombreTipo,
                Descripcion = modelo.Descripcion
                
            };
        }

        // Copiar de entidad a modelo
        public static Expression<Func<entidades.ValidadorEntidades.TiposEscuela, TiposEscuela>> CopiarDeEntidad => static e =>
            new TiposEscuela
            {
                    TipoEscuelaId = e.TipoEscuelaId,
                    NombreTipo = e.NombreTipo,
                    Descripcion = e.Descripcion,

            };

        // Agregar
        public async Task<string> AgregarAsync(TiposEscuela modelo)
        {
            var entidad = CopiarDeModelo(modelo);
            _context.TiposEscuela.Add(entidad);
            await _context.SaveChangesAsync();
            return "Tipo de escuela agregada correctamente.";
        }

        // Actualizar
        public async Task<string> ActualizarAsync(TiposEscuela modelo)
        {
            var entidad = await _context.TiposEscuela.FirstOrDefaultAsync(e => e.TipoEscuelaId == modelo.TipoEscuelaId);
            if (entidad == null) return "El tipo de escuela no existe.";

            entidad.TipoEscuelaId = modelo.TipoEscuelaId;
            entidad.NombreTipo = modelo.NombreTipo;
            entidad.Descripcion = modelo.Descripcion;

            await _context.SaveChangesAsync();
            return "Tipo de escuela actualizada correctamente.";
        }

        // Eliminar
        public async Task<string> EliminarAsync(Guid id)
        {
            var entidad = await _context.TiposEscuela.FirstOrDefaultAsync(e => e.TipoEscuelaId == id);
            if (entidad == null) return "Tipo de escuela no encontrada.";

            _context.TiposEscuela.Remove(entidad);
            await _context.SaveChangesAsync();
            return "Tipo de escuela eliminada correctamente.";
        }

        // Obtener una
        public async Task<TiposEscuela?> ObtenerAsync(Guid id)
        {
            return await _context.TiposEscuela
                .Include(e => e.TipoEscuelaId)
                .AsNoTracking()
                .Select(CopiarDeEntidad)
                .FirstOrDefaultAsync(e => e.TipoEscuelaId == id);
        }

        // Obtener todas
        public async Task<List<TiposEscuela>> ObtenerTodasAsync()
        {
            return await _context.TiposEscuela
                .Include(e => e.TipoEscuelaId)
                .AsNoTracking()
                .Select(CopiarDeEntidad)
                .ToListAsync();
        }
    }
}
