using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RVOE.entidades.ValidadorEntidades;

public partial class EnvioRecepcion
{
    [Key]
    [StringLength(10)]
    public string EnvioRecepcionId { get; set; } = null!;

    public Guid EscuelaId { get; set; }

    [StringLength(10)]
    public string TipoMovimiento { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [StringLength(150)]
    public string? Descripcion { get; set; }

    [ForeignKey("EscuelaId")]
    [InverseProperty("EnvioRecepcion")]
    public virtual Escuelas Escuela { get; set; } = null!;
}
