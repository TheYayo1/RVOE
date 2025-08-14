using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RVOE.ValidadorEntidades.modelValidador;

[Keyless]
public partial class TiposEscuela
{
    public Guid TipoEscuelaId { get; set; }

    /// <summary>
    /// Si es pública, privada, etc
    /// </summary>
    [StringLength(20)]
    public string NombreTipo { get; set; } = null!;

    [StringLength(20)]
    public string? Descripcion { get; set; }

    [ForeignKey("TipoEscuelaId")]
    public virtual Escuelas TipoEscuela { get; set; } = null!;
}
