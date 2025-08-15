using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RVOE.modelos.ValidadorModelos;

public partial class TiposEscuela
{
    [Key]
    public Guid TipoEscuelaId { get; set; }

    [StringLength(20)]
    public string NombreTipo { get; set; } = null!;

    [StringLength(20)]
    public string? Descripcion { get; set; }

    [InverseProperty("TipoEscuela")]
    public virtual ICollection<Escuelas> Escuelas { get; set; } = new List<Escuelas>();
}

